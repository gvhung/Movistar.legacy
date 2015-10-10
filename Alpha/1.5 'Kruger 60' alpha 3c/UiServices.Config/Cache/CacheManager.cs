﻿// Copyright (C) 2014-2015, Codeplex user AlphaCentaury
// All rights reserved, except those granted by the governing license of this software. See 'license.txt' file in the project root for complete license information.

using Project.DvbIpTv.Common.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Project.DvbIpTv.UiServices.Configuration.Cache
{
    public class CacheManager
    {
        private string BaseDirectory;
        private char[] DocNameOffendingChars;

        public CacheManager(string baseDirectory)
        {
            BaseDirectory = baseDirectory;
            if (!Directory.Exists(BaseDirectory))
            {
                Directory.CreateDirectory(BaseDirectory);
            } // if

            var invalidFileChars = Path.GetInvalidFileNameChars();
            DocNameOffendingChars = new char[invalidFileChars.Length + 2];
            DocNameOffendingChars[0] = '.';
            DocNameOffendingChars[1] = ' ';
            Array.Copy(invalidFileChars, 0, DocNameOffendingChars, 2, invalidFileChars.Length);
        } // constructor

        public void SaveXml<T>(string documentType, string name, int version, T xmlTree) where T: class
        {
            var path = Path.Combine(BaseDirectory, GetSafeDocumentName(documentType, name, ".xml"));
            XmlSerialization.Serialize(path, Encoding.UTF8, xmlTree);
        } // SaveXml

        public T LoadXml<T>(string documentType, string name) where T : class
        {
            try
            {
                var path = Path.Combine(BaseDirectory, GetSafeDocumentName(documentType, name, ".xml"));
                if (!File.Exists(path))
                {
                    return null;
                } // if

                return XmlSerialization.Deserialize<T>(path, false);
            }
            catch
            {
                // supress exception; behave as if document is not in the cache
                return null;
            } // try-catch
        } // LoadXml

        public CachedXmlDocument<T> LoadXmlDocument<T>(string documentType, string name) where T : class
        {
            try
            {
                var path = Path.Combine(BaseDirectory, GetSafeDocumentName(documentType, name, ".xml"));
                if (!File.Exists(path))
                {
                    return null;
                } // if

                var document =  XmlSerialization.Deserialize<T>(path, false);
                if (document == null) return null;

                var dateC = File.GetCreationTime(path);
                var dateW = File.GetLastWriteTime(path);

                return new CachedXmlDocument<T>(document, documentType, name, new Version(), (dateC > dateW) ? dateC : dateW);
            }
            catch
            {
                // supress exception; behave as if document is not in the cache
                return null;
            } // try-catch
        } // LoadXmlDocument<T>

        /// <summary>
        /// Builds a filename, replacing all filesystem invalid characters (including '.' and spaces) with the given character
        /// </summary>
        /// <param name="documentType">Optional. Must not contain invalid chars</param>
        /// <param name="documentName">Name of the file/document</param>
        /// <param name="extension">File extension</param>
        /// <param name="replacingChar">(Optional) Character to mark a replaced, invalid character</param>
        /// <returns>A filesystem-safe filename</returns>
        public string GetSafeDocumentName(string documentType, string documentName, string extension, char? replacingChar = '~')
        {
            StringBuilder buffer;
            int startIndex, index;

            documentName = documentName.ToLowerInvariant();
            buffer = new StringBuilder(documentType.Length + 2 + documentName.Length * 2);
            if (documentType != null)
            {
                buffer.Append('{');
                buffer.Append(documentType.ToLowerInvariant());
                buffer.Append("} ");
            } // if

            // quick test: any offending char?
            index = documentName.IndexOfAny(DocNameOffendingChars);
            if (index < 0)
            {
                buffer.Append(documentName);
                buffer.Append(extension);
                return buffer.ToString();
            } // if

            startIndex = 0;
            while (index >= 0)
            {
                if (index != startIndex)
                {
                    buffer.Append(documentName.Substring(startIndex, (index - startIndex)));
                    if (replacingChar.HasValue) buffer.Append(replacingChar.Value);
                } // if

                startIndex = index + 1;
                index = (startIndex < documentName.Length) ? documentName.IndexOfAny(DocNameOffendingChars, startIndex) : -1;
            } // while

            // add final text
            if (startIndex < documentName.Length)
            {
                buffer.Append(documentName.Substring(startIndex, documentName.Length - startIndex));
            } // if
            buffer.Append(extension);

            return buffer.ToString();
        } // GetSafeDocumentName
    } // class CacheManager
} // namespace
