﻿namespace PeliculasApi.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.JsonPatch;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using PeliculasApi.DTOs;
    using PeliculasApi.Entidades;
    using PeliculasApi.Servicios;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/actores")]
    public class ActoresController : CustomBaseController
    {
        private readonly ApplicacionDbContext context;
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly string contenedor = "actores";

        public ActoresController(ApplicacionDbContext context, IMapper mapper, IAlmacenadorArchivos almacenadorArchivos) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.almacenadorArchivos = almacenadorArchivos;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActorDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            return await Get<Actor, ActorDTO>(paginacionDTO);
            //var queryable = context.Actores.AsQueryable();
            //await HttpContext.InsertarParametrosPaginacion(queryable, paginacionDTO.CantidadRegistrosPorPagina);
            //return mapper.Map<List<ActorDTO>>(await queryable.Paginar(paginacionDTO).ToListAsync());
        }

        [HttpGet("{id:int}", Name = "obtenerActor")]
        public async Task<ActionResult<ActorDTO>> Get(int id)
        {
            return await Get<Actor, ActorDTO>(id);
            //var entidad = await context.Actores.FirstOrDefaultAsync(x => x.Id == id);
            //if (entidad == null)
            //{
            //    return NotFound();
            //}

            //return mapper.Map<ActorDTO>(entidad);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ActorCreacionDTO actorCreacionDTO)
        {
            var entidad = mapper.Map<Actor>(actorCreacionDTO);

            if (actorCreacionDTO.Foto != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await actorCreacionDTO.Foto.CopyToAsync(memoryStream);
                    var contenido = memoryStream.ToArray();
                    var extension = Path.GetExtension(actorCreacionDTO.Foto.FileName);
                    entidad.Foto = await almacenadorArchivos.GuardarArchivo(contenido, extension, contenedor,
                    actorCreacionDTO.Foto.ContentType);
                }
            }

            context.Add(entidad);
            await context.SaveChangesAsync();
            var actorDTO = mapper.Map<ActorDTO>(entidad);
            return new CreatedAtRouteResult("obtenerActor", new { id = actorDTO.Id }, actorDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromForm] ActorCreacionDTO actorCreacionDTO)
        {
            var actorDB = await context.Actores.FirstOrDefaultAsync(x => x.Id == id);

            if (actorDB == null) { return NotFound(); }

            actorDB = mapper.Map(actorCreacionDTO, actorDB);

            if (actorCreacionDTO.Foto != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await actorCreacionDTO.Foto.CopyToAsync(memoryStream);
                    var contenido = memoryStream.ToArray();
                    var extension = Path.GetExtension(actorCreacionDTO.Foto.FileName);
                    actorDB.Foto = await almacenadorArchivos.EditarArchivo(contenido, extension, contenedor,
                        actorDB.Foto,
                        actorCreacionDTO.Foto.ContentType);
                }
            }

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<ActorPatchDTO> patchDocument)
        {
            return await Patch<Actor, ActorPatchDTO>(id, patchDocument);
            //if (patchDocument == null)
            //{
            //    return BadRequest();
            //}

            //var entidadDB = await context.Actores.FirstOrDefaultAsync(x => x.Id == id);
            //if (entidadDB == null)
            //{
            //    return NotFound();
            //}

            //var entidadDTO = mapper.Map<PeliculaDTO>(entidadDB);
            //patchDocument.ApplyTo(entidadDTO, ModelState);

            //var esValido = TryValidateModel(entidadDTO);

            //if (!esValido)
            //{
            //    string messages = string.Join("/", ModelState.Values
            //                            .SelectMany(x => x.Errors)
            //                            .Select(x => x.ErrorMessage));
            //    var data = messages.Split("/");
            //    return BadRequest(ModelState);
            //}

            //mapper.Map(entidadDTO, entidadDB);
            //await context.SaveChangesAsync();

            //return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            return await Delete<Actor>(id);
            //var existe = await context.Actores.AnyAsync(x => x.Id == id);
            //if (!existe)
            //{
            //    return NotFound();
            //}

            //context.Remove(new Actor() { Id = id });
            //await context.SaveChangesAsync();
            //return NoContent();
        }
    }
}