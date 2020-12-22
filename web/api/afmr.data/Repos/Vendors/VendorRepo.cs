using afmr.data.Models.Vendors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace afmr.data.Repos.Vendors
{
    public class VendorRepo : RepoBase<Vendor>, IVendorRepo
    {
        public VendorRepo(MarketResearchDbContext dbContext) : base(dbContext) { }

        public Vendor Get(int id)
        {
            return Get()
                .Where(e => e.Id == id)
                .Include(e => e.VendorContacts)
                .Include(e => e.VendorParts)
                .Include(e => e.SetAside)
                .Include(e => e.VendorNotes)
                    .ThenInclude(e => e.UserAccount)
                .FirstOrDefault();
        }

        public IEnumerable<Vendor> Get(IEnumerable<int> ids)
        {
            return Get()
                .Where(e => ids.Contains(e.Id))
                .ToList();
        }

        public Vendor GetBySustainmentId(string sustainmentId)
        {
            return Get()
                .Where(e => e.SustainmentId == sustainmentId)
                .Include(e => e.VendorContacts)
                .Include(e => e.VendorParts)
                .Include(e => e.SetAside)
                .Include(e => e.VendorNotes)
                    .ThenInclude(e => e.UserAccount)
                .FirstOrDefault();
        }

        public IEnumerable<Vendor> GetByIds(string nameOrCageOrDuns)
        {
            return Get()
                .Include(e => e.VendorContacts)
                .Include(e => e.VendorParts)
                .Include(e => e.SetAside)
                .Include(e => e.VendorNotes)
                    .ThenInclude(e => e.UserAccount)
                //.Where(e => e.CAGECode.Contains(nameOrCageOrDuns) ||
                //e.DUNSId.Contains(nameOrCageOrDuns) ||
                //e.Name.Contains(nameOrCageOrDuns))
                .Where(e => e.CAGECode.StartsWith(nameOrCageOrDuns) ||
                e.DUNSId.StartsWith(nameOrCageOrDuns) ||
                e.Name.StartsWith(nameOrCageOrDuns))
                .Take(50)
                //.Distinct()
                .OrderBy(e => e.Name)
                .ToList();
        }

        public IEnumerable<Vendor> Get(IEnumerable<string> cageCodes, IEnumerable<string> dunsIds, IEnumerable<string> names)
        {
            return Get()
                //.Include(e => e.VendorContacts)
                .Where(e => cageCodes.Contains(e.CAGECode) ||
                dunsIds.Contains(e.DUNSId) ||
                names.Contains(e.Name))
                .ToList();
        }

        public IEnumerable<Vendor> Get(IEnumerable<string> sustainmentIds)
        {
            return Get()
                .Where(e => sustainmentIds.Contains(e.SustainmentId))
                .ToList();
        }
    }
}
