Imports System.Data
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Web.Http.Description
Imports WebApplication1

Namespace Controllers
    Public Class ItemController
        Inherits System.Web.Http.ApiController

        Private db As New DBModel

        ' GET: api/Item
        Function GetShopBridgeItems() As IQueryable(Of ShopBridgeItem)
            Return db.ShopBridgeItems
        End Function

        ' GET: api/Item/5
        <ResponseType(GetType(ShopBridgeItem))>
        Function GetShopBridgeItem(ByVal id As Integer) As IHttpActionResult
            Dim shopBridgeItem As ShopBridgeItem = db.ShopBridgeItems.Find(id)
            If IsNothing(shopBridgeItem) Then
                Return NotFound()
            End If

            Return Ok(shopBridgeItem)
        End Function

        ' PUT: api/Item/5
        <ResponseType(GetType(Void))>
        Function PutShopBridgeItem(ByVal id As Integer, ByVal shopBridgeItem As ShopBridgeItem) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = shopBridgeItem.ItemID Then
                Return BadRequest()
            End If

            db.Entry(shopBridgeItem).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (ShopBridgeItemExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/Item
        <ResponseType(GetType(ShopBridgeItem))>
        Function PostShopBridgeItem(ByVal shopBridgeItem As ShopBridgeItem) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.ShopBridgeItems.Add(shopBridgeItem)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = shopBridgeItem.ItemID}, shopBridgeItem)
        End Function

        ' DELETE: api/Item/5
        <ResponseType(GetType(ShopBridgeItem))>
        Function DeleteShopBridgeItem(ByVal id As Integer) As IHttpActionResult
            Dim shopBridgeItem As ShopBridgeItem = db.ShopBridgeItems.Find(id)
            If IsNothing(shopBridgeItem) Then
                Return NotFound()
            End If

            db.ShopBridgeItems.Remove(shopBridgeItem)
            db.SaveChanges()

            Return Ok(shopBridgeItem)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function ShopBridgeItemExists(ByVal id As Integer) As Boolean
            Return db.ShopBridgeItems.Count(Function(e) e.ItemID = id) > 0
        End Function
    End Class
End Namespace