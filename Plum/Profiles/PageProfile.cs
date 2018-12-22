using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Plum.Models;

namespace Plum.Profiles
{
    public class PageProfile : Profile
    {
        public PageProfile()
        {
            CreateMap<IEnumerable<string>, ISet<Privilege>>()
                .ConstructUsing(src => Privilege.All().Where(p => src.Contains(p.Alias)).ToHashSet());
        }
    }
}
