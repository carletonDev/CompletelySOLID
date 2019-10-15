﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassLibrary.Context;
using ClassLibrary.Models;
using ClassLibrary.Interfaces;

namespace CompletelySOLID.Controllers.HospitalController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IDbContextFactory _context;

        public RoomsController(IDbContextFactory context)
        {
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        public IEnumerable<Rooms> GetRooms()
        {
            return _context.HospitalContext().Rooms;
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRooms([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rooms = await _context.HospitalContext().Rooms.FindAsync(id);

            if (rooms == null)
            {
                return NotFound();
            }

            return Ok(rooms);
        }

        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRooms([FromRoute] int id, [FromBody] Rooms rooms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rooms.RoomId)
            {
                return BadRequest();
            }

            _context.HospitalContext().Entry(rooms).State = EntityState.Modified;

            try
            {
                await _context.HospitalContext().SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Rooms
        [HttpPost]
        public async Task<IActionResult> PostRooms([FromBody] Rooms rooms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HospitalContext().Rooms.Add(rooms);
            await _context.HospitalContext().SaveChangesAsync();

            return CreatedAtAction("GetRooms", new { id = rooms.RoomId }, rooms);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRooms([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rooms = await _context.HospitalContext().Rooms.FindAsync(id);
            if (rooms == null)
            {
                return NotFound();
            }

            _context.HospitalContext().Rooms.Remove(rooms);
            await _context.HospitalContext().SaveChangesAsync();

            return Ok(rooms);
        }

        private bool RoomsExists(int id)
        {
            return _context.HospitalContext().Rooms.Any(e => e.RoomId == id);
        }
    }
}