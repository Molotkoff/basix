using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basix.Util.Segment
{
    public class Segment<T> where T : ISegment
    {
        private struct NamedSegment
        {
            public int Position { get; set; }
            public T Value { get; set; }

            public NamedSegment(int position, T value)
            {
                this.Position = position;
                this.Value = value;
            }
        }

        public int Length
        {
            get
            {
                var length = 0;

                foreach (var segment in segments)
                    length += segment.Length();

                return length;
            }
        }

        private List<T> segments;
        private Dictionary<string, NamedSegment> named;

        public Segment()
        {
            this.segments = new List<T>();
            this.named = new Dictionary<string, NamedSegment>();
        }

        public void Add(string name, T segment)
        {
            var namedSegment = new NamedSegment(segments.Count, segment);
            
            named.Add(name, namedSegment);
            segments.Add(segment);
        }

        public int IndexOfSegment(string name)
        {
            var named = this.named[name];
            var position = named.Position;
            var index = 0;

            for (int i = 0; i < position; i++)
                index += segments[i].Length();

            return index;
        }

        public int IndexOfSegment(T segment)
        {
            foreach (var candidate in named)
                if (candidate.Value.Value.Equals(segment))
                    return IndexOfSegment(candidate.Key);

            throw new Exception("No found segment ");
        }


        public IEnumerable<R> All<R>(Func<T, IEnumerable<R>> productor)
        {
            var all = new List<R>();

            foreach (var segment in segments)
                all.AddRange(productor(segment));

            return all;
        }
    }
}