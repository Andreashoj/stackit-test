import React from "react";

const Modal = () => {
  return (
    <section id="modal" class="modal modal--hidden">
      <div className="modal__wrapper">
        <header className="modal__header">
          <h2 className="modal__title">Modal Header</h2>
          <a
            className="modal__close"
            title="Luk"
            href="#"
            onclick="document.getElementById('modal').classList.toggle('modal--hidden')"
          >
            &#x2715;
          </a>
        </header>
        <div className="modal__content">
          <p>Dummy content</p>
        </div>
      </div>
    </section>
  );
};

export default Modal;
