using Microsoft.EntityFrameworkCore;
using TasksManager.Data;
using TasksManager.Models;

namespace TasksManager.BLL
{
    public class TasksBLL
    {
        private readonly ApplicationDbContext _contexto;

        public TasksBLL(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public bool AddTask(Tasks tasks)
        {
            if (tasks.Id == 0)
            {
                return Insertar(tasks);
            }
            else
            {
                return Modificar(tasks);
            }
        }

        public bool Insertar(Tasks taskModel)
        {
            try
            {
                if (_contexto == null || _contexto.Tasks == null)
                {
                    return false;
                }
                //Agregar el id de usuario
                _contexto.Tasks.Add(taskModel);
                int cantidad = _contexto.SaveChanges();
                return cantidad > 0;
            }

            catch (Exception ex)
            {
                // Manejar otras excepciones según sea necesario
                Console.WriteLine($"Otro error al insertar: {ex.Message}");
                throw;
            }
        }

        public Tasks BuscarTask(int id)
        {
            var result = _contexto.Tasks
                .FirstOrDefault(task => task.Id == id);

            return result;
        }


        public List<Tasks> GetTasks(string userId)
        {
            return _contexto.Tasks
                .Where(t => t.UserId == userId)
                .ToList();
        }

        public void ModificarTask(Tasks taskModel)
        {
            _contexto.Entry(taskModel).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public bool Modificar(Tasks taskModel)
        {
            try
            {
                _contexto.Entry(taskModel).State = EntityState.Modified;
                int cantidad = _contexto.SaveChanges();
                return cantidad > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar: {ex.Message}");
                throw;
            }
        }

        public bool Eliminar(int Id)
        {
            bool eliminado = false;

            try
            {
                var taskModel = _contexto.Tasks.Find(Id);

                if (taskModel != null)
                {
                    _contexto.Tasks.Remove(taskModel);
                    eliminado = _contexto.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar: {ex.Message}");
                throw;
            }

            return eliminado;
        }
    }
}
