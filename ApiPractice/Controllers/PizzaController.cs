using Microsoft.AspNetCore.Mvc;
using ApiPractice.Models;
using ApiPractice.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;

namespace ApiPractice.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    /// <summary>
    ///    Obtiene todas la pizzas
    /// </summary>
    /// <returns>
    ///     Devuelve una instancia de ActionResult de tipo List<Pizza>
    ///     El tipo ActionResult es la clase base para los resultados de acción de un método de controlador
    /// </returns>
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();


    /// <summary>
    ///     Consulta la base de datos (almacenamiento en caché local en memoria) en busca 
    ///     de una pizza que coincida con el parámetro de identificación proporcionado
    /// </summary>
    /// <param name="id">Valor del parámetro id incluido en el segmento de URL después de pizza/</param>
    /// <returns>El objeto pizza correspondido</returns>
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get([FromRoute] int id)
    {
        var pizza = PizzaService.Get(id);
        if (pizza is null)
        {
            return NotFound();
        }

        return pizza;
    }

    /// <summary>
    ///    Agrega una nueva pizza a la base de datos (almacenamiento en caché local en memoria).
    /// </summary>
    /// <param name="pizza">Objeto pizza a agregar</param>
    /// <returns>
    ///    Devuelve una respuesta IActionResult: 201 (CreatedAtAction) si se creó; de lo contrario, 
    ///    devuelve un 400 (BadRequest).
    /// </returns>
    [HttpPost]
    public IActionResult Create([FromBody] Pizza pizza)
    {
        // This code will save the pizza and return a result

        try
        {
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    /*
     * IActionResult le permite al cliente saber si la solicitud se realizó correctamente 
     * y proporciona el ID de la pizza recién creada. IActionResult utiliza códigos de 
     * estado HTTP estándar, por lo que puede integrarse fácilmente con los clientes independientemente 
     * del idioma o la plataforma en la que se ejecuten.
     */

    /// <summary>
    ///     Actualiza una pizza en la base de datos (almacenamiento en caché local en memoria).
    /// </summary>
    /// <param name="id">Id del valor de la pizza a actualizar.</param>
    /// <param name="pizza">Objeto pizza a actualizar.</param>
    /// <returns>Devuelve un 204 si la pizza se actualizó; de lo contrario, devuelve un 404</returns>
    [HttpPut]
    public IActionResult Update([FromBody] int id, [FromBody] Pizza pizza)
    {
        // This code will update the pizza and return a result
    }

    /// <summary>
    ///     Elimina la pizza de la base de datos (almacenamiento en caché local en memoria).
    /// </summary>
    /// <param name="id">Id del objeto pizza a eliminar</param>
    /// <returns>
    ///     Devuelve un 204 si la pizza se eliminó correctamente; de lo contrario, devuelve un 404.
    /// </returns>
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        // This code will delete the pizza and return a result
    }
}
