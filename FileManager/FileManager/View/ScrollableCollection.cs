using System.Collections.Generic;

namespace FileManager.View
{
    internal sealed class ScrollableCollection<T>
    {
        public T this[int index] => _allContent[_startIndex + index];

        private readonly int _visibleContentLength;
        private int _startIndex;
        private int _endIndex;
        private List<T> _allContent;

        public ScrollableCollection(int visibleContentLength) : this(visibleContentLength, null)
        {
        }
        public ScrollableCollection(int visibleContentLength, List<T> content)
        {
            _allContent = content != null ? content : new();
            _visibleContentLength = visibleContentLength;

            SetStartIndexPosition();
        }

        public int CurrentSlideContentCount => _allContent.Count > 0 ? _endIndex - _startIndex + 1 : 0;
        public int SlidesCount
        {
            get
            {
                if (_allContent.Count != 0)
                {
                    int result = _allContent.Count / _visibleContentLength;
                    return _allContent.Count % _visibleContentLength > 0 
                        ? _allContent.Count / _visibleContentLength + 1 : _allContent.Count / _visibleContentLength;
                }
                return 0;
            }
        }
        public int CurrentSlideIndex 
        {
            get
            {
                if(_startIndex == 0 || SlidesCount <= 1)
                {
                    return 0;
                }
                return (_startIndex + 1) % _visibleContentLength > 0 
                    ? (_startIndex + 1) / _visibleContentLength : (_startIndex + 1) / _visibleContentLength - 1;
            }
        }
        public void ScrollUp()
        {
            if (_startIndex == 0)
            {
                return;
            }
            int tempStartIndex = _startIndex;
            _startIndex = _startIndex - _visibleContentLength < 0 ? 0 : _startIndex - _visibleContentLength;
            _endIndex -= (tempStartIndex - _startIndex);
        }
        public void ScrollUp1()
        {
            if (_startIndex == 0)
            {
                return;
            }

            if(CurrentSlideContentCount < _visibleContentLength)
            {
                _endIndex = _startIndex - 1;
                _startIndex = _endIndex - _visibleContentLength < 0 ? 0 : _startIndex - _visibleContentLength;
            }
            else
            {
                _startIndex = _startIndex - _visibleContentLength < 0 ? 0 : _startIndex - _visibleContentLength;
                _endIndex -= _visibleContentLength;
            }
        }
        public void ScrollDown()
        {
            if (_endIndex == _allContent.Count - 1)
            {
                return;
            }
            int tempEndIndex = _endIndex;
            _endIndex = _endIndex + _visibleContentLength > _allContent.Count - 1 
                ? _allContent.Count - 1 : _endIndex + _visibleContentLength;
            _startIndex += (_endIndex - tempEndIndex);
        }
        public void ScrollDown1()
        {
            if (_endIndex == _allContent.Count - 1)
            {
                return;
            }
            _endIndex = _endIndex + _visibleContentLength > _allContent.Count - 1
                ? _allContent.Count - 1 : _endIndex + _visibleContentLength;
            _startIndex = _startIndex + _visibleContentLength > _allContent.Count - 1
                ? _startIndex : _startIndex + _visibleContentLength;
        }
        public void Clear()
        {
            _allContent.Clear();
            SetStartIndexPosition();
        }
        public void Add(T item)
        {
            _allContent.Add(item);
            SetStartIndexPosition();
        }
        public void Add(List<T> collection)
        {
            _allContent.AddRange(collection);
            SetStartIndexPosition();
        }
        public void Insert(int index, T item)
        {
            _allContent.Insert(index, item);
            SetStartIndexPosition();
        }
        private void SetStartIndexPosition()
        {
            _startIndex = 0;
            if (_visibleContentLength >= _allContent.Count)
            {
                _endIndex = _allContent.Count != 0 ? _allContent.Count - 1 : 0;
            }
            else
            {
                _endIndex = _visibleContentLength != 0 ? _visibleContentLength - 1 : 0;
            }
        }
    }
}
