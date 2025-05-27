import React from "react";

function ItemDetails({ name, description }) {
  return (
    <div className="itemDetails">
      <div className="fallowContainer">
        <p> {name}</p>
        <div className="two-line-ellipsis">
          <p>{description}</p>
        </div>
      </div>
    </div>
  );
}

export default ItemDetails;
