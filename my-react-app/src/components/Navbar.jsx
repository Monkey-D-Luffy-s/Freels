import React from "react";
import { useState } from "react";
import { Outlet, Link } from "react-router-dom";

function Navbar() {
  const [isOpen, setIsOpen] = useState(false);
  return (
    <div>
      <nav className="navbar">
        <div className="title">
          <div className="navbar-logo">Instagram</div>
        </div>
        <div className="section1" placeholder="search" type="text">
          <i class="bi bi-search"></i>
          <input className="Serachbar"></input>
        </div>
        <button className="navbar-toggle" onClick={() => setIsOpen(!isOpen)}>
          ☰
        </button>

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
