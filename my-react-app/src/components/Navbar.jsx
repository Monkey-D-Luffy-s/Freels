import React from "react";
import { useState } from "react";
import { Outlet, Link } from "react-router-dom";
import logo from "../../public/logo.png";
import Search from "./Search";

function Navbar() {
  const [isOpen, setIsOpen] = useState(false);
  return (
    <div>
      <nav className="navbar">
        <div className="title">
          <div className="navbar-logo">
            <img src={logo} alt="Logo" />
          </div>
        </div>
        <Search />

        <div className={`navbar-links ${isOpen ? "open" : ""}`}>
          <Link to="/" onClick={() => setIsOpen(false)}>
            Home
          </Link>
          <Link to="/upload" onClick={() => setIsOpen(false)}>
            Upload Video
          </Link>
          <Link to="/Reels" onClick={() => setIsOpen(false)}>
            Reels
          </Link>
        </div>
      </nav>
      <div>
        <Outlet />
      </div>
    </div>
  );
}

export default Navbar;
