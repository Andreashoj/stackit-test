import React from "react";

const ErrorLog = ({ error }) => {
  return (
    <div className="log">
      <ul className=" error">
        {error.map(error => {
          return (
            <li key={error.id} className="log__item">
              <p className="log__id error">Error: #{error.id}</p>
              <p>{error.message}</p>
            </li>
          );
        })}
      </ul>
    </div>
  );
};

export default ErrorLog;
