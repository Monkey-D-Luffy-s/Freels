import React, { useEffect, useState } from "react";
import axios from "axios";

function UploadVideo() {
  function generateGuid() {
    return crypto.randomUUID(); // ✅ supported in most modern browsers
  }

  const onFileSubmit = async (e) => {
    e.preventDefault();
    const form = e.target;

    const formData = new FormData();
    formData.append("file", form.file.files[0]);
    formData.append("title", form.Title.value);
    formData.append("userID", generateGuid());

    try {
      const response = await axios.post(
        "https://localhost:7001/api/Reels/UploadShort",
        formData,
        {
          headers: {
            "Content-Type": "multipart/form-data",
          },
        }
      );

      console.log("Upload successful:", response.data);
    } catch (error) {
      console.error("Upload failed:", error);
    }
  };

  return (
    <div className="Uploading">
      <form onSubmit={onFileSubmit}>
        <div className="formItems">
          <label className="file" htmlFor="file" id="file">
            Upload your Reel
          </label>
          <input type="file" name="file" className="fileButton" accept="mp4" />
          <label className="Title" htmlFor="Title">
            Title
          </label>
          <input className="fileButton" name="Title" id="Title" type="text" />

          <button type="submit" className="fileButton">
            Upload
          </button>
        </div>
      </form>
    </div>
  );
}

export default UploadVideo;
