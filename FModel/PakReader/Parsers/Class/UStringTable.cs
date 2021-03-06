﻿using PakReader.Parsers.Objects;
using System.Collections;
using System.Collections.Generic;

namespace PakReader.Parsers.Class
{
    public sealed class UStringTable : IUExport
    {
        readonly Dictionary<string, object> Map;

        internal UStringTable(PackageReader reader)
        {
            var _ = new UObject(reader); // will break

            Map = new Dictionary<string, object>(2)
            {
                { "StringTable", new FStringTable(reader) },
                { "StringTableId", reader.ReadFName() }
            };
        }

        public object this[string key] => Map[key];
        public IEnumerable<string> Keys => Map.Keys;
        public IEnumerable<object> Values => Map.Values;
        public int Count => Map.Count;
        public bool ContainsKey(string key) => Map.ContainsKey(key);
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => Map.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Map.GetEnumerator();

        public bool TryGetValue(string key, out object value) => Map.TryGetValue(key, out value);
    }
}
