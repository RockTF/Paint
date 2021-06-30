using System;
using NewPaitnt.Interfaces;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Drawing;
using DTO;
using System.IO;
using System.Drawing.Imaging;
using NewPaitnt.Enum;

namespace NewPaitnt.Implementation
{
    public class Storage : IStorage
    {
        private static Storage _storage;

        private List<IDrawable> _figures;
        private List<IDrawable> _history;
        private List<IDrawable> _buffer;
        private List<string> _figuresNames;

        private FigureFactory _figureFactory;

        private string _jsonText;

        private Bitmap _bitmapToSave;

        private string _pictureToLoad;

        private Storage()
        {
            _figures = new List<IDrawable>();
            _figuresNames = new List<string>();
            _buffer = new List<IDrawable>();

            _figureFactory = new FigureFactory();
        }

        public static Storage Initialize()
        {
            if (_storage == null)
            {
                _storage = new Storage();
            }
            return _storage;
        }

        public void AddFigure(IDrawable figure)
        {
            _figures.Add(figure);
            _figuresNames.Add(figure.FigureName);
        }

        public IDrawable GetFigure(int position)
        {
            if (position >= 0 && position < _figures.Count)
            {
                return _figures[position];
            }
            else
            {
               throw new IndexOutOfRangeException(); 
            }
        }

        public IDrawable GetLastFigure()
        {
            return _figures[_figures.Count - 1];
        }

        public List<IDrawable> GetAllFigures()
        {
            return _figures;
        }

        public string GetFigureName(int position)
        {
            if (position >= 0 && position < _figures.Count)
            {
                return _figuresNames[position];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public List<string> GetFiguresNames()
        {
            return _figuresNames;
        }

        public int GetCount()
        {
            return _figures.Count;
        }

        public void RemoveFigureAt(int position)
        {
            if (position >= 0 && position <= _figures.Count)
            {
                _figures.RemoveAt(position); 
                _figuresNames.RemoveAt(position);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void TransferToBuffer() 
        {
            if (_figures.Count > 0)
            {
                if (_buffer == null)
                {
                    _buffer = new List<IDrawable>();
                }
                _buffer.Add(_figures[^1]);
                _figures.RemoveAt(_figures.Count - 1);
                _figuresNames.RemoveAt(_figuresNames.Count - 1);
            }
        }

        public void TransferToFigure()
        {
            if (_buffer != null && _buffer.Count != null && _figures != null && _buffer.Count > 0) 
            {
                _figures.Add(_buffer[^1]);
                _buffer.RemoveAt(_buffer.Count - 1);
                _figuresNames.Add(_figures[^1].FigureName);
            }
        }

        public void Clear()
        {
            _figures.Clear();
            _buffer.Clear();
            _figuresNames.Clear();
        }

        public string GetJson()
        {
            _jsonText = JsonConvert.SerializeObject(_figures);
            return _jsonText;
        }
        public void SetJson(string json)
        {
            _jsonText = json;
            List<IDrawableDTO> temp = JsonConvert.DeserializeObject<List<IDrawableDTO>>(_jsonText, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            Clear();
            foreach (IDrawableDTO figure in temp)
            {
                _figures.Add(_figureFactory.ConvertToFigure(figure));
                _figuresNames.Add(_figures[^1].FigureName);
            }
        }

        public PictureDTO GetPictureDTO(int userId, string pictureName, EPictureTypes pictureType)
        {
            PictureDTO pictureDTO = new PictureDTO();
            pictureDTO.UserId = userId;
            pictureDTO.PictureName = pictureName;
            pictureDTO.PictureType = pictureType;

            if (pictureType == EPictureTypes.json)
            {
                pictureDTO.PictureContent = GetJson();
                pictureDTO.PictureSize = _jsonText.Length;
            }
            else
            {
                (pictureDTO.PictureContent, pictureDTO.PictureSize) = ConvertPictureToString(pictureType);
            }

            CalculateStatistics(ref pictureDTO);

            return pictureDTO;
        }

        private (string, int) ConvertPictureToString(EPictureTypes pictureType)
        {
            MemoryStream memoryStream = new MemoryStream();
            switch (pictureType)
            {
                case EPictureTypes.bmp:
                    _bitmapToSave.Save(memoryStream, ImageFormat.Bmp);
                    break;
                case EPictureTypes.gif:
                    _bitmapToSave.Save(memoryStream, ImageFormat.Gif);
                    break;
                case EPictureTypes.jpg:
                    _bitmapToSave.Save(memoryStream, ImageFormat.Jpeg);
                    break;
                case EPictureTypes.png:
                    _bitmapToSave.Save(memoryStream, ImageFormat.Png);
                    break;
            }

            byte[] pictureBytes = memoryStream.ToArray();
            int pictureSize = pictureBytes.Length;
            string pictureString = Convert.ToBase64String(pictureBytes);
            return (pictureString, pictureSize);
        }

        public Bitmap RestorePicture()
        {
            byte[] restoredBytes = Convert.FromBase64String(_pictureToLoad);
            MemoryStream restoredStream = new MemoryStream(restoredBytes);
            _bitmapToSave = (Bitmap)Image.FromStream(restoredStream);
            return _bitmapToSave;
        }

        public void SetBitmapToSave(Bitmap bitmap)
        {
            _bitmapToSave = bitmap;
        }

        public void SetPictureToLoad(string picture)
        {
            _pictureToLoad = picture;
        }

        private void CalculateStatistics(ref PictureDTO pictureDTO)
        {
            foreach (IDrawable figure in _figures)
            {
                pictureDTO.Dictionary[(int)figure.FigureType] = new KeyValuePair<string, int>(pictureDTO.Dictionary[(int)figure.FigureType].Key, pictureDTO.Dictionary[(int)figure.FigureType].Value + 1);
            }
        }
    }
}
