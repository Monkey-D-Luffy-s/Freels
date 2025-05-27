import React from "react";

function AddComment() {
  return (
    <div className="addComment">
      <input
        className="commentInput"
        type="text"
        name="addCommentInput"
        placeholder="Add a comment"
      ></input>
    </div>
  );
}

export default AddComment;
