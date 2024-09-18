using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;

namespace UescColcicAPI.Services.BD;

public class StudentsCRUD : IStudentsCRUD
{
    private static readonly List<Student> Students = new()
   {
      new Student { Name = "Douglas", Email = "douglas.cic@uesc.br" },
      new Student { Name = "Estevão", Email = "estevao.cic@uesc.br" },
      new Student { Name = "Gabriel", Email = "gabriel.cic@uesc.br" },
      new Student { Name = "Gabriela", Email = "gabriela.cic@uesc.br" }
   };
    public void Create(Student entity)
    {
        Students.Add(entity); //Adiciona o um objeto do tipo Student na lista
    }
    public void Delete(Student entity)
    {
        // Captura o email que quer deletar (considerando email como id único)
        string refStudentEmail = entity.Email;

        // Encontra o estudante na lista com o email especificado
        Student studentToRemove = Students.FirstOrDefault(studentInList => studentInList.Email == refStudentEmail);

        // Se o estudante foi encontrado, remove da lista
        if (studentToRemove != null)
        {
            Students.Remove(studentToRemove);
        }
    }

    public IEnumerable<Student> ReadAll()
    {
        return Students;
    }

    public void Update(Student entity)
    {
         /*Captura o email que quer deletar (considerando email como id único)
        string refStudentEmail = entity.Email;
        string refStudentName = entity.Name;
        */
        string refStudentEmail = entity.Email;
        //preciso para achar a referencia ao objeto que possui um email igual ao Student entity do parâmetro
        Student studentToUpdate = Students.FirstOrDefault(studentInList => studentInList.Email == refStudentEmail);

        if(studentToUpdate != null){
            int indexUpdate = Students.IndexOf(studentToUpdate);
            Students[indexUpdate].Email+=".alterado";
        }
    }
}
