using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {

        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetByID(int id)
        {
            return _writerDal.Get(x => x.WriterID == id);
        }

        public List<Writer> GetList()
        {
            return _writerDal.List();
        }

        public void WriterAdd(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            Writer wu = GetByID(writer.WriterID);
            wu.WriterName = writer.WriterName;
            wu.WriterSurName = writer.WriterSurName;
            wu.WriterMail = writer.WriterMail;
            wu.WriterPassword = writer.WriterPassword;
            wu.WriterAbout = writer.WriterAbout;
            wu.WriterImage = writer.WriterImage;
            wu.WriterTitle = writer.WriterTitle;
            _writerDal.Update(writer);
        }
    }
}
