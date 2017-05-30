using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Infrastructure.Data.Repositories
{
    public interface IEFRepositorio<TEntity> where TEntity : class
    {
        /// <summary>
        /// Devuelve el AuditableObjectContext
        /// </summary>

        /// <summary>
        /// Guarda los cambios del contexto
        /// </summary>
        int SaveChanges();

        /// <summary>
        /// Añade un elemento dentro del repositorio
        /// </summary>
        /// <param name="item">Elemento a añadir al repositorio</param>
        void Add(TEntity item);

        /// <summary>
        /// Marca el elemento para su borrado
        /// </summary>
        /// <param name="item">Elemento a borrar</param>
        void Remove(TEntity item);

        /// <summary>
        /// Mark as updated
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        TEntity Update(TEntity element);
        
        /// <summary>
        /// Se obtiene el elemento 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Get(object id);

        /// <summary>
        /// Obtiene el elemento
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        TEntity Get(TEntity element);
        /// <summary>
        /// Obtiene todos los elementos del tipo {TEntity} en repositorio
        /// </summary>
        /// <returns>Lista de elementos seleccionados</returns>
        List<TEntity> GetAll();

        /// <summary>
        /// Obtiene todos los elementos del tipo {TEntity} en repositorio
        /// </summary>
        /// <param name="specifications">Primero se debe obtener de la propiedad this.BuildQuery() y añadir los filtros requeridos</param> 
        /// <returns>Lista de elementos seleccionados</returns>
        List<TEntity> GetBySpecifications(IQueryable<TEntity> specifications);

        /// <summary>
        /// Obtiene todos los elementos del tipo {TEntity} en el repositorio
        /// </summary>
        /// <param name="startRowIndex">Número de índice donde empieza la página. Por ejemplo si queremos la página número 3 entonces startIndex = 3 *maxRows </param>
        /// <param name="maximunRows">´Número de elementos por página</param>
        /// <param name="orderByExpression">Orden por expression para la query. Es obligatorio</param>
        /// <param name="ascending">Especifica si el orden es ascendente</param>
        /// <param name="count">Devuelve el número de elementos encontrados</param> 
        /// <returns>Lista de elementos seleccionados</returns>
        List<TEntity> GetPagedElements<S>(int startRowIndex, int maximunRows, System.Linq.Expressions.Expression<Func<TEntity, S>> orderByExpression, bool ascending, out int count);

        /// <summary>
        /// Obtiene todos los elementos del tipo {TEntity} en el repositorio
        /// </summary>
        /// <param name="startRowIndex">Número de índice donde empieza la página. Por ejemplo si queremos la página número 3 entonces startIndex = 3 *maxRows </param>
        /// <param name="maximunRows">´Número de elementos por página</param>
        /// <param name="orderByExpression">Orden por expression para la query. Es obligatorio</param>
        /// <param name="ascending">Especifica si el orden es ascendente</param>
        /// <param name="count">Devuelve el número de elementos encontrados</param> 
        /// <param name="specifications">Primero se debe obtener de la propiedad Query y añadir los filtros requeridos</param> 
        /// <returns>Lista de elementos seleccionados</returns>
        List<TEntity> GetPagedElements<S>(int startRowIndex, int maximunRows, System.Linq.Expressions.Expression<Func<TEntity, S>> orderByExpression, bool ascending, out int count, IQueryable<TEntity> specifications);

        /// <summary>
        /// Devuelve el IQueryable de la entidad
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> BuildQuery();
    }
}
