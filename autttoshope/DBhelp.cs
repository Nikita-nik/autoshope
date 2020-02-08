using autttoshope.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace autttoshope
{
    public class DBhelp
    {
        internal ApplicationContext context;

        public DBhelp(ApplicationContext context)
        {
            this.context = context;
        }

        async public Task<List<SelectListItem>> GetDataSelectListItems<T>() where T : class
        {
            DbSet<T> dbSet = context.Set<T>();

            return await (dbSet.Select(a => new SelectListItem()
            {
                Value = ((IBaseModel)a).Id.ToString(),
                Text = ((IBaseModel)a).Name
            })).ToListAsync();
        }
    }


}
