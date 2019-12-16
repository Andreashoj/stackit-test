import React, { useState, useContext, useEffect } from "react";
import List from "../../components/List/List";
import Heading from "../../components/Heading/Heading";
import Chart from "react-apexcharts";

const DashBoard = () => {
  const user = JSON.parse(sessionStorage.getItem("user"));

  const [ListItems, setListState] = useState({
    machines: [],
    opes: [],
    companies: []
  });

  const [chart, setChart] = useState({
    options: {
      fill: {
        colors: ["#4563bf"]
      },
      chart: {
        id: "basic-bar"
      },
      xaxis: {
        categories: [
          "Maskine 1",
          "Maskine 2",
          "Maskine 3",
          "Maskine 4",
          "Maskine 5",
          "Maskine 6",
          "Maskine 7",
          "Maskine 8",
          "Maskine 9"
        ]
      }
    },
    series: [
      {
        name: "series-1",
        data: [30, 40, 45, 50, 49, 60, 70, 91].sort(() => Math.random() - 0.5)
      }
    ],
    title: {
      style: {
        fontSize: "1rem",
        color: "black",
        backgroundColor: "#303030",
        display: "flex",
        justifyContent: "center",
        alignItems: "center"
      }
    }
  });

  return (
    user && (
      <div className="dashboard-wrapper">
        <Heading title={`${user.username} - ${user.firstName}`} />
        <List items={ListItems} />
        <div className="chart-container">
          <h2>Machine statistics</h2>
          <Chart
            style={chart.title.style}
            options={chart.options}
            series={chart.series}
            type="bar"
            width="100%"
          />
        </div>
      </div>
    )
  );
};

export default DashBoard;
