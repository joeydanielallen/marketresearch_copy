using afmr.data.Repos;
using afmr.data.Repos.Recents;
using afmr.data.Repos.Templates;
using afmr.data.Repos.Vendors;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data
{
    public interface IUnitOfWork : IDisposable
    {
        IVendorContactRepo VendorContactRepo { get; }

        IRecentUserVendorRepo RecentUserVendorRepo { get; }

        IVendorNoteRepo VendorNoteRepo { get; }

        IUserOrgRepo UserOrgRepo { get; }

        ITemplateInstanceAnswerRepo TemplateInstanceAnswerRepo { get; }

        ISetAsideRepo SetAsideRepo { get; }

        IVendorRepo VendorRepo { get; }

        ITemplateInitiateVendorRepo TemplateInitiateVendorRepo { get; }

        IUserAccountRepo UserAccountRepo { get; }

        IMaterialMgmtAggregateCodeRepo MaterialMgmtAggregateCodeRepo { get; }

        ITemplateInstanceRepo TemplateInstanceRepo { get; }

        ITemplateInstanceUserRepo TemplateInstanceUserRepo { get; }

        ITemplateRepo TemplateRepo { get; }

        void Save();
    }
}
