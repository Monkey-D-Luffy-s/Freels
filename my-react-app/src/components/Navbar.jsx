import React from "react";
import { useState } from "react";
import { Outlet, Link } from "react-router-dom";

function Navbar() {
  const [isOpen, setIsOpen] = useState(false);
  return (
    <div>
      <nav className="navbar">
        <div className="navbar-logo">MyApp</div>

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
