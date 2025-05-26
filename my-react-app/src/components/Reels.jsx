import React, { useEffect, useRef } from "react";
import { useLoaderData } from "react-router-dom";
import axios from "axios";

const baseurl = "https://localhost:7001";
function Reels() {
  const videos = useLoaderData();
  const videoRefs = useRef([]);

  useEffect(() => {
    const observer = new IntersectionObserver(
      (entries) => {
        entries.forEach((entry) => {
          const video = entry.target;
          if (entry.isIntersecting) {
            video.play();
          } else {
            video.pause();
          }
        });
      },
      {
        threshold: 0.5, // Trigger when 50% of the video is visible
      }
    );

    videoRefs.current.forEach((video) => {
      if (video) observer.observe(video);
    });

    return () => {
      videoRefs.current.forEach((video) => {
        if (video) observer.unobserve(video);
      });
    };
  }, [videos]);

  return (
    <div className="reelsContainer">
      {videos != null && (
        <ul className="list-ul">
          {videos.data.map((video, index) => (
            <li key={video.Id} className="listItem">
              <video
                ref={(el) => (videoRefs.current[index] = el)}
                src={`${baseurl}${video.videoURL}`}
                muted
                loop
                playsInline
                controls
                className="videoSource"
              />
              <div className="contents">
                <div>
                  <i class="bi bi-heart"></i>
                  <i class="bi bi-chat"></i>
                  <i class="bi bi-send"></i>
                </div>
                <div>
                  <i class="bi bi-bookmark"></i>
                </div>
              </div>
              <div className="likes">
                <p>123 likes</p>
              </div>
              <div className="itemDetails">
                <div className="fallowContainer">
                  <p> {video.videoName}</p>
                  <div className="two-line-ellipsis">
                    <p>{video.videoDescription}</p>
                  </div>
                </div>
              </div>
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}

export default Reels;

export const loadReels = async () => {
  try {
    const response = await axios.get(
      "https://localhost:7001/api/Reels/GetThree"
    );
    if (response != null) {
      console.log("fetched successful:", response.data);
      return response;
    }
  } catch (error) {
    console.error("fetch failed:", error);
  }
};
