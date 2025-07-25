﻿//-----------------------------------------------------------------------
// <copyright file="IntPtrSerializer.cs" company="Sirenix IVS">
// Copyright (c) 2018 Sirenix IVS
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

namespace OdinSerializer
{
    using System;

    /// <summary>
    /// Serializer for the <see cref="IntPtr"/> type.
    /// </summary>
    /// <seealso cref="IntPtr" />
    public sealed class IntPtrSerializer : Serializer<IntPtr>
    {
        /// <summary>
        /// Reads a value of type <see cref="IntPtr" />.
        /// </summary>
        /// <param name="reader">The reader to use.</param>
        /// <returns>
        /// The value which has been read.
        /// </returns>
        public override IntPtr ReadValue(IDataReader reader)
        {
            string name;
            var entry = reader.PeekEntry(out name);

            if (entry == EntryType.Integer)
            {
                long value;
                if (reader.ReadInt64(out value) == false)
                {
                    reader.Context.Config.DebugContext.LogWarning("Failed to read entry '" + name + "' of type " + entry.ToString());
                }
                return new IntPtr(value);
            }
            else
            {
                reader.Context.Config.DebugContext.LogWarning("Expected entry of type " + EntryType.Integer.ToString() + ", but got entry '" + name + "' of type " + entry.ToString());
                reader.SkipEntry();
                return default(IntPtr);
            }
        }

        /// <summary>
        /// Writes a value of type <see cref="IntPtr" />.
        /// </summary>
        /// <param name="name">The name of the value to write.</param>
        /// <param name="value">The value to write.</param>
        /// <param name="writer">The writer to use.</param>
        public override void WriteValue(string name, IntPtr value, IDataWriter writer)
        {
            FireOnSerializedType();
            writer.WriteInt64(name, (long)value);
        }
    }
}