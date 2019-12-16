import React from "react";

const CurrentJob = ({ machine }) => {
  return (
    <div className="current-job">
      <table>
        <thead>
          <tr>
            <th>Current Job</th>
            <th>Est. time</th>
          </tr>
        </thead>
        <tr>
          <td>Job 2382</td>
          <td>8 min</td>
        </tr>
        <tr>
          <td>Job 2383</td>
          <td>15 min</td>
        </tr>
        <tr>
          <td>Job 2384</td>
          <td>19 min</td>
        </tr>
      </table>
    </div>
  );
};

export default CurrentJob;
