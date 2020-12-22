using afmr.data;
using afmr.domain.Mappers;
using afmr.domain.Security;
using afmr.model;
using afmr.model.Vendors;
using System;
using System.Collections.Generic;
using System.Linq;


namespace afmr.domain.Services
{
    public class VendorNoteService : ServiceBase, IVendorNoteService
    {
        public VendorNoteService(
            ILogger logger,
            IUnitOfWork unitOfWork,
            IUserIdentity userIdentity,
            IConfig config)
            : base(logger, unitOfWork, userIdentity, config) { }

        public int Create(VendorNote note)
        {
            if(note == null)
            {
                throw new InvalidOperationException(nameof(note) + " parameter cannot be null");
            }

            var data = note.Map(_userIdentity.UserId);

            using (_unitOfWork)
            {
                _unitOfWork.VendorNoteRepo.Insert(data);
                _unitOfWork.Save();
                return data.Id;
            }
        }

        public void Delete(int id)
        {
            using (_unitOfWork)
            {
                var data = _unitOfWork.VendorNoteRepo.Get(id);
                if (data == null)
                {
                    return;
                }
                _unitOfWork.VendorNoteRepo.Delete(data);
                _unitOfWork.Save();
            }
        }

        public VendorNote Get(int id)
        {
            using (_unitOfWork)
            {
                var data = _unitOfWork.VendorNoteRepo.Get(id);
                return data.Map();
            }
        }

        public VendorNote Update(VendorNote note)
        {
            if (note == null)
            {
                throw new InvalidOperationException(nameof(note) + " parameter cannot be null");
            }

            var data = note.Map(_userIdentity.UserId);

            if(data == null)
            {
                return null;
            }

            using (_unitOfWork)
            {
                _unitOfWork.VendorNoteRepo.Update(data);
                _unitOfWork.Save();
            }

            return note;
        }
    }
}
