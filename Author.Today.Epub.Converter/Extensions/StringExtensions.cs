﻿using System.IO;
using System.Text;
using HtmlAgilityPack;

namespace Author.Today.Epub.Converter.Extensions {
    public static class StringExtensions {
        /// <summary>
        /// Конвертация строки в Html документ
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static HtmlDocument AsHtmlDoc(this string self) {
            var doc = new HtmlDocument();
            doc.LoadHtml(self);
            return doc;
        }

        /// <summary>
        /// Конвертация строки в Xhtml документ
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static HtmlDocument AsXHtmlDoc(this string self) {
            HtmlNode.ElementsFlags.Remove("style");
            HtmlNode.ElementsFlags.Remove("title");

            var doc = new HtmlDocument {
                OptionFixNestedTags = true,
                OptionAutoCloseOnEnd = true,
                OptionOutputAsXml = true,
            };

            doc.LoadHtml(self);
            return doc;
        }

        /// <summary>
        /// Удаление из строки запрещенных символов для пути
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string RemoveInvalidChars(this string self) {
            var sb = new StringBuilder(self);
            foreach (var invalidFileNameChar in Path.GetInvalidFileNameChars()) {
                sb.Replace(invalidFileNameChar, ' ');
            }

            return sb.ToString();
        }

        /// <summary>
        /// Обертывание строки кавычками
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string CoverQuotes(this string self) {
            return "\"" + self + "\"";
        }
    }
}