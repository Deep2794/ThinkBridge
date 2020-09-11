using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ShopBridgeItemsAPI.Models;

namespace ShopBridgeItemsAPI.Controllers
{
    public class ItemController : ApiController
    {
        private DBThinkBridgeModel db = new DBThinkBridgeModel();

        // GET: api/Item
        public IQueryable<ShopBridgeItem> GetShopBridgeItems()
         {
            return db.ShopBridgeItems;
        }

        // GET: api/Item/5
        [ResponseType(typeof(ShopBridgeItem))]
        public IHttpActionResult GetShopBridgeItem(int id)
        {
            ShopBridgeItem shopBridgeItem = db.ShopBridgeItems.Find(id);
            if (shopBridgeItem == null)
            {
                return NotFound();
            }

            return Ok(shopBridgeItem);
        }

        // PUT: api/Item/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShopBridgeItem(int id, ShopBridgeItem shopBridgeItem)
        {
            

            if (id != shopBridgeItem.ItemID)
            {
                return BadRequest();
            }

            db.Entry(shopBridgeItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopBridgeItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Item
        [ResponseType(typeof(ShopBridgeItem))]
        public IHttpActionResult PostShopBridgeItem(ShopBridgeItem shopBridgeItem)
        {


            db.ShopBridgeItems.Add(shopBridgeItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = shopBridgeItem.ItemID }, shopBridgeItem);
        }

        // DELETE: api/Item/5
        [ResponseType(typeof(ShopBridgeItem))]
        public IHttpActionResult DeleteShopBridgeItem(int id)
        {
            ShopBridgeItem shopBridgeItem = db.ShopBridgeItems.Find(id);
            if (shopBridgeItem == null)
            {
                return NotFound();
            }

            db.ShopBridgeItems.Remove(shopBridgeItem);
            db.SaveChanges();

            return Ok(shopBridgeItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShopBridgeItemExists(int id)
        {
            return db.ShopBridgeItems.Count(e => e.ItemID == id) > 0;
        }
    }
}