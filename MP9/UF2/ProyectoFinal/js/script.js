document.addEventListener('DOMContentLoaded', function () {
  
  // Funcionalidad del formulario de contacto
  const contactForm = document.getElementById('contactForm');
  if (contactForm) {
    contactForm.addEventListener('submit', function (event) {
      event.preventDefault();
      Swal.fire({
        icon: 'success',
        title: 'Mensaje enviado',
        text: 'Pronto nos pondremos en contacto contigo.',
        confirmButtonText: 'Aceptar'
      }).then(() => {
        contactForm.reset();
      });
    });
  }

  // Configuración del video: iniciar en el segundo 2
  const video = document.querySelector('video');
  if (video) {
    video.addEventListener('canplay', function() {
      setTimeout(() => {
        video.currentTime = 2;
      }, 200);
    });
  }
});
