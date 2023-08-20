function getCursos() {
  /*  alert('si')*/
    $.ajax({
        type: "POST",
        url: "/Cursos/getCursoss",
        success: (data) => {
            $.each(data, (i, val) => {
                var row = `<tr>
                                   <td>${i.CodigoCurso}</td>
                                   <td>${i.Nombre}</td>
                                   <td>${i.CantidadCreditos}</td>
                               </tr>`;
                $('#listCursos').append(row);
            });
        },
        error: (error) => {
            console.log(error);
            return false;
        }
    });
    return true;
}