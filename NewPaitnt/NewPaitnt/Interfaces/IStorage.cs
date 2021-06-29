using DTO;
using System.Collections.Generic;
using System.Drawing;

namespace NewPaitnt.Interfaces
{
    public interface IStorage
    {
        void AddFigure(IDrawable figure);
        IDrawable GetFigure(int position);
        IDrawable GetLastFigure();
        List<IDrawable> GetAllFigures();
        string GetFigureName(int position);
        List<string> GetFiguresNames();
        void RemoveFigureAt(int position);
        int GetCount();
        void TransferToBuffer();
        void TransferToFigure();
        void Clear();
        string GetJson();
        public void SetJson(string json);
        PictureDTO GetPictureDTO(int userId, string pictureName, EPictureTypes pictureType);
        Bitmap RestorePicture();
        void SetBitmapToSave(Bitmap bitmap);
        void SetPictureToLoad(string picture);
    }
}
