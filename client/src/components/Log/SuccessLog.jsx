import React from "react";

const SuccessLog = ({ success }) => {
  return (
    <div>
      <ul className="log success">
        {success.map(log => {
          return (
            <li key={log.id} className="log__item success">
              <p className="log__id success">Job: #{log.id}</p>
              <p>{log.message}</p>
            </li>
          );
        })}
      </ul>
    </div>
  );
};

export default SuccessLog;
