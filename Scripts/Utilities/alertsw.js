function Alertsw(icon="error",title="¡Ha ocurrido un error!",text="Vuelve a intentarlo",timer=0)
{
    // Alerta con timer
    if(timer!=0)
    {
        let timerInterval
        Swal.fire({
        icon: `${icon}`,
        title: `${title}`,
        text: `${text}`,
        timer: `${timer}`,
        timerProgressBar: true,
        didOpen: () => {
            Swal.showLoading()
           
        },
        willClose: () => {
            clearInterval(timerInterval)
        }
        }).then((result) => {
        /* Read more about handling dismissals below */
        if (result.dismiss === Swal.DismissReason.timer) {
        }
        })
    }
    else
    {
        Swal.fire({
            icon: `${icon}`,
            title: `${title}`,
            text: `${text}`
          })
    }

}