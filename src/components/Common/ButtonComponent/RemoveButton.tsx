import React from "react";

const RemoveButton = () => {
  return (
    <div className='flex justify-center items-center translate-x-[.2px] translate-y-[.5px]'>
      <svg
        width="12"
        height="12"
        viewBox="0 0 24 24"
        fill="none"
        xmlns="http://www.w3.org/2000/svg">
        <path
          d="M19 5L5 19M5 5L19 19"
          stroke="#fff"
          strokeWidth="3"
          strokeLinejoin="round"
        />
      </svg>
    </div>
  );
};

export default RemoveButton;
