import React from "react";
import { slide as Menu } from "react-burger-menu";
import logo from "../../assets/icons/logo_stackit.svg";

const MobileNav = ({ userType }) => {
  let listItem_operator;
  if (userType === ("s_admin" || "k_admin")) {
    listItem_operator = (
      <a id="contact" className="menu-item" href="/contact">
        Operators
      </a>
    );
  } else {
    listItem_operator = null;
  }

  return (
    <nav className="nav">
      <div className="nav__wrapper--sidebar">
        <Menu pageWrapId={"page-wrap"} width={"50%"}>
          <img src={logo} alt="" className="bm-menu__logo" />
          <a id="home" className="menu-item" href="/">
            Dashboard
          </a>
          <a id="about" className="menu-item" href="/about">
            Machines
          </a>
          {listItem_operator}
          <a
            onClick={e => e.preventDefault()}
            className="menu-item--small"
            href="/"
          >
            Logout
          </a>
        </Menu>
      </div>
    </nav>
  );
};

export default MobileNav;
