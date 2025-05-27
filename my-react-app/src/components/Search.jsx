import React from "react";

function Search() {
  return (
    <div className="searchSection">
      <div className="section1" placeholder="search" type="text">
        <i class="bi bi-search"></i>
        <input className="Serachbar"></input>
      </div>
      <button className="navbar-toggle" onClick={() => setIsOpen(!isOpen)}>
        ☰
      </button>
    </div>
  );
}

export default Search;
