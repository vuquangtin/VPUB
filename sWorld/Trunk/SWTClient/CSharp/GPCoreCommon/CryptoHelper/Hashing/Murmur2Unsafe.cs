﻿// Copyright (c) 2012, Event Store LLP
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are
// met:
// 
// Redistributions of source code must retain the above copyright notice,
// this list of conditions and the following disclaimer.
// Redistributions in binary form must reproduce the above copyright
// notice, this list of conditions and the following disclaimer in the
// documentation and/or other materials provided with the distribution.
// Neither the name of the Event Store LLP nor the names of its
// contributors may be used to endorse or promote products derived from
// this software without specific prior written permission
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
// HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
// LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
// THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// 
//
// This code is extended from Davy Landman
// Originally released under MPL 1.1 http://landman-code.blogspot.com/2009/02/c-superfasthash-and-murmurhash2.html
//
using System;

namespace CryptoHelper.Hashing
{
    public class Murmur2Unsafe
    {
        private const uint Seed = 0xc58f1a7b;
        private const uint m = 0x5bd1e995;
        private const Int32 r = 24;

        public unsafe UInt32 Hash(string s)
        {
            var data = s.ToCharArray();
            fixed (char* input = &data[0])
            {
                return Hash((byte*)input, (uint)data.Length * sizeof(char), Seed);
            }
        }

        public unsafe uint Hash(byte[] data)
        {
            fixed (byte* input = &data[0])
            {
                return Hash(input, (uint)data.Length, Seed);
            }
        }

        public unsafe uint Hash(byte[] data, int offset, uint len, uint seed)
        {
            fixed (byte* input = &data[offset])
            {
                return Hash(input, len, seed);
            }
        }

        private unsafe static uint Hash(byte* data, uint len, uint seed)
        {
            UInt32 h = seed ^ len;
            UInt32 numberOfLoops = len >> 2; // div 4

            UInt32* realData = (UInt32*)data;
            while (numberOfLoops > 0)
            {
                UInt32 k = *realData;

                k *= m;
                k ^= k >> r;
                k *= m;

                h *= m;
                h ^= k;

                realData++;
                numberOfLoops--;
            }
            var tail = (byte*)realData;
            switch (len & 3) // mod 4
            {
                case 3:
                    h ^= (uint)(tail[2] << 16);
                    h ^= (uint)(tail[1] << 8);
                    h ^= tail[0];
                    h *= m;
                    break;
                case 2:
                    h ^= (uint)(tail[1] << 8);
                    h ^= tail[0];
                    h *= m;
                    break;
                case 1:
                    h ^= tail[0];
                    h *= m;
                    break;
            }

            // Do a few final mixes of the hash to ensure the last few
            // bytes are well-incorporated.

            h ^= h >> 13;
            h *= m;
            h ^= h >> 15;

            return h;
        }
    }
}
