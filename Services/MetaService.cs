using Microsoft.EntityFrameworkCore;
using Parcial1_AP1_CristopherMarte.DAL;
using Parcial1_AP1_CristopherMarte.Models;
using System.Linq.Expressions;

namespace Parcial1_AP1_CristopherMarte.Services;

public class MetaService
{
	private readonly Contexto _contexto;

    public MetaService(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Existe(int metaId) {
        return await _contexto.Metas.AnyAsync(a => a.MetaId == metaId);
    }

    public async Task<bool> Crear(Metas meta) {
        if(! await Existe(meta.MetaId)) {
            return await Insertar(meta);
        }
        else {
            return await Modificar(meta);
        }
    }

	private async Task<bool> Insertar(Metas meta) {
		_contexto.Metas.Add(meta);
        return await _contexto.SaveChangesAsync() > 0;
	}

	private async Task<bool> Modificar(Metas meta) {
        _contexto.Metas.Update(meta);
        var modificado = await _contexto.SaveChangesAsync() > 0;
        return modificado;
	}

    public async Task<Metas?> Buscar(int metaId) {
        return await _contexto.Metas
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.MetaId == metaId);
    }

    public async Task<bool> Eliminar(Metas meta) {
        return await _contexto.Metas
            .AsNoTracking()
            .Where(m => m.MetaId == meta.MetaId)
            .ExecuteDeleteAsync() > 0;
    }

    public List<Metas> ObtenerLista(Expression<Func<Metas, bool>> criterio) {
        return _contexto.Metas
            .AsNoTracking()
            .Where(criterio)
            .ToList();
    }
	
}
