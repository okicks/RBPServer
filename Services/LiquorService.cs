﻿using Data;
using Models.Favorites;
using Models.Liquor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LiquorService
    {
        public bool CreateLiquor(LiquorCreate model)
        {
            var entity =
                new Liquor()
                {
                    Name = model.Name,
                    Category = model.Category,
                    PercentAlcohol = model.PercentAlcohol,
                    Origin = model.Origin,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Liquors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<FavoriteLiquorsListItem> GetFaveLiquors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .FavoriteLiquors
                    .Select(e =>
                    new FavoriteLiquorsListItem
                    {
                        Id = e.Id,
                        Favoriter = e.Favoriter,
                        LiquorName = e.Liquor.Name,
                        IsStarred = e.IsStarred
                    });

                return query.ToArray();
            }
        }

        public IEnumerable<LiquorListItem> GetLiquors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var liquorListItems =
                    ctx
                    .Liquors
                    .Select(e => new LiquorListItem
                    {
                        Id = e.Id,
                        Name = e.Name,
                    }).ToArray();

                foreach (var liquor in liquorListItems)
                {
                    liquor.AverageRating = AverageLiquorRating(liquor.LiquorRatings);
                }

                return liquorListItems;
            }
        }
        private double AverageLiquorRating(ICollection<LiquorRating> liquorRatings)
        {
            if (liquorRatings == null || liquorRatings.Count == 0)
            {
                return 0;
            }

            var sum = 0d;
            foreach (var rating in liquorRatings)
            {
                sum += rating.Rating;
            }

            return sum / liquorRatings.Count();
        }

        public LiquorDetail GetLiquorById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Liquors
                    .Single(e => e.Id == id);

                return
                    new LiquorDetail
                    {
                        Name = entity.Name,
                        Category = entity.Category,
                        PercentAlcohol = entity.PercentAlcohol,
                        Origin = entity.Origin
                    };
            }
        }

        public bool UpdateLiquor(LiquorEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Liquors
                    .Single(e => e.Id == model.Id);

                entity.Name = model.Name;
                entity.Category = model.Category;
                entity.PercentAlcohol = model.PercentAlcohol;
                entity.Origin = model.Origin;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLiquor(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Liquors
                    .Single(e => e.Id == id);

                ctx.Liquors.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
