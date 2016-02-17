using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common.CommandTrees;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Xml;
using System.Xml.Serialization;
using BusinessLogic.Implementations;
using BusinessLogic.Interfaces;
using Domain.Entities;

namespace BusinessLogic
{
    //Класс, через который происходит обмен данными в приложении
    public class DataManager
    {
        private ILoginsRepository logins;
        private IAuthorsRepository authors;
        private IGenresRepository genres;
        private IDateRepository dates;
        private IPlaysRepository plays;
        private IOrdersRepository orders;
        private IRepertoireRepository repertories;
        private ICategoryRepository categories;
        private ICategoriesInfoRepository categoriesInfo;
        private PrimaryMembershipProvider provider;
        private CustomRoleProvider roleProvider;
        private ICourierInfoRepository courierInfo;

        public DataManager(ILoginsRepository logins, IAuthorsRepository authors,
                            IGenresRepository genres, IDateRepository dates,
                            IPlaysRepository plays,IOrdersRepository orders, 
                            IRepertoireRepository repertories, ICategoryRepository categories,
                            ICategoriesInfoRepository categoriesInfo, ICourierInfoRepository courierInfo,
                            PrimaryMembershipProvider provider, CustomRoleProvider roleProvider)
        {
            this.logins = logins;
            this.genres = genres;
            this.authors = authors;
            this.dates = dates;
            this.plays = plays;
            this.orders = orders;
            this.provider = provider;
            this.repertories = repertories;
            this.categories = categories;
            this.categoriesInfo = categoriesInfo;
            this.courierInfo = courierInfo;
            this.roleProvider = roleProvider;
        }

        public ILoginsRepository Logins {get { return logins; } }
        public IAuthorsRepository Authors { get { return authors; } }
        public IGenresRepository Genres { get { return genres; } }
        public IDateRepository Dates { get { return dates; } }
        public IPlaysRepository Plays { get { return plays; } }
        public IOrdersRepository Orders { get { return orders; } }
        public PrimaryMembershipProvider MembershipProvider {get { return provider; } }
        public CustomRoleProvider RoleProvider { get { return roleProvider; } }
        public IRepertoireRepository Repertoiries {get { return repertories;} }
        public ICategoryRepository Categories { get { return categories; } }
        public ICategoriesInfoRepository CategoriesInfo { get { return categoriesInfo; } }
        public ICourierInfoRepository CourierInfo { get { return courierInfo; } }

    }
}
