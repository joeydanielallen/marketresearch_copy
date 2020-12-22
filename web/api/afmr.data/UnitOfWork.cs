using afmr.data.Repos;
using afmr.data.Repos.Recents;
using afmr.data.Repos.Templates;
using afmr.data.Repos.Vendors;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly MarketResearchDbContext _marketResearchDbContext;
        private bool disposed = false;

        public UnitOfWork(
            string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException("connectionString parameter must not be null or empty");
            }

            _marketResearchDbContext = new MarketResearchDbContext(connectionString);
        }





        // REPO Properties
        private IVendorContactRepo _vendorContactRepo;
        public IVendorContactRepo VendorContactRepo
        { get { return BuildRepo(ref _vendorContactRepo, () => new VendorContactRepo(_marketResearchDbContext)); } }

        private IRecentUserVendorRepo _recentUserVendorRepo;
        public IRecentUserVendorRepo RecentUserVendorRepo
        { get { return BuildRepo(ref _recentUserVendorRepo, () => new RecentUserVendorRepo(_marketResearchDbContext)); } }

        private IVendorNoteRepo _vendorNoteRepo;
        public IVendorNoteRepo VendorNoteRepo
        { get { return BuildRepo(ref _vendorNoteRepo, () => new VendorNoteRepo(_marketResearchDbContext)); } }

        private IUserOrgRepo _userOrgRepo;
        public IUserOrgRepo UserOrgRepo
        { get { return BuildRepo(ref _userOrgRepo, () => new UserOrgRepo(_marketResearchDbContext)); } }

        private ITemplateInstanceAnswerRepo _templateInstanceAnswerRepo;
        public ITemplateInstanceAnswerRepo TemplateInstanceAnswerRepo
        { get { return BuildRepo(ref _templateInstanceAnswerRepo, () => new TemplateInstanceAnswerRepo(_marketResearchDbContext)); } }

        private ISetAsideRepo _setAsideRepo;
        public ISetAsideRepo SetAsideRepo
        { get { return BuildRepo(ref _setAsideRepo, () => new SetAsideRepo(_marketResearchDbContext)); } }

        private IVendorRepo _vendorRepo;
        public IVendorRepo VendorRepo
        { get { return BuildRepo(ref _vendorRepo, () => new VendorRepo(_marketResearchDbContext)); } }

        private ITemplateInitiateVendorRepo _templateInitiateVendorRepo;
        public ITemplateInitiateVendorRepo TemplateInitiateVendorRepo
        { get { return BuildRepo(ref _templateInitiateVendorRepo, () => new TemplateInitiateVendorRepo(_marketResearchDbContext)); } }

        private ITemplateInstanceRepo _templateInstanceRepo;
        public ITemplateInstanceRepo TemplateInstanceRepo
        { get { return BuildRepo(ref _templateInstanceRepo, () => new TemplateInstanceRepo(_marketResearchDbContext)); } }

        private ITemplateInstanceUserRepo _templateInstanceUserRepo;
        public ITemplateInstanceUserRepo TemplateInstanceUserRepo
        { get { return BuildRepo(ref _templateInstanceUserRepo, () => new TemplateInstanceUserRepo(_marketResearchDbContext)); } }

        private ITemplateRepo _templateRepo;
        public ITemplateRepo TemplateRepo
        { get { return BuildRepo(ref _templateRepo, () => new TemplateRepo(_marketResearchDbContext)); } }

        private IUserAccountRepo _useraccountRepo;
        public IUserAccountRepo UserAccountRepo
        { get { return BuildRepo(ref _useraccountRepo, () => new UserAccountRepo(_marketResearchDbContext)); } }

        private IMaterialMgmtAggregateCodeRepo _mmacRepo;
        public IMaterialMgmtAggregateCodeRepo MaterialMgmtAggregateCodeRepo
        { get { return BuildRepo(ref _mmacRepo, () => new MaterialMgmtAggregateCodeRepo(_marketResearchDbContext)); } }



        // Methods
        public void Save()
        {
            _marketResearchDbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _marketResearchDbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        private TRepo BuildRepo<TRepo>(ref TRepo repo, Func<TRepo> builder)
        {
            if (repo == null)
            {
                repo = builder();
            }

            return repo;
        }

    }
}
