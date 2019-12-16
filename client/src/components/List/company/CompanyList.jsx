import React, {useEffect, useState, useContext} from 'react';
import { UserContext } from "../../../context/UserContext";
import { useHistory } from "react-router-dom";
import { paginate } from "../../../utills/pagination/pagination";
import UsePageSizeItems from "../../hooks/usePageSizeItems.jsx";
import ModalAdd from "../opeList/ModalAdd.jsx";
import useSearch from "../../hooks/useSearch.jsx";
import Pagination from "../../common/Pageination";


const CompanyList = ({ dashboard, searchNum}) => {

  let history = useHistory();
  const {user, http, isAdmin} = useContext(UserContext);
  const pageSize = dashboard !== undefined ? 5 : UsePageSizeItems();
  const [modal, setModal] = useState(false);
  const [modalData, setModalData] = useState();
  const [modalAdd, setModalAdd] = useState(false);
  
  const count = dashboard !== undefined ? 0 : companyList.length;

  const [companyList, setCompanies] = useState({
    companiesArr: [],
    pageSize,
    count,
    currentPage: 1
  });

   useEffect(() => {
    const fetchData = async () => {
      try{
        const res = await http.get("/companies"); 
        if(res){
          setCompanies(prevState => ({
            ...prevState,
            companiesArr: res.data 
          }));
        }
      }catch(e){
        console.log(e);
      }
    }
    fetchData();
  }, []);

   const companies = paginate(
    companyList.companiesArr,
    companyList.currentPage,
    companyList.pageSize
  );
  
  const handleRedirect = id => {
    history.push(`/company/${id}`);
  };

   //Handle the event and update the state
   const handlePageChange = page => {
    setCompanies(prevState => ({
      ...prevState,
      currentPage: page
    }));
  };

   
return (
<>
  <h1>Company list</h1>
  <section className="List-wrapper">
  <table className="listWrapper">
          <thead className="listHead">
            <tr>
              <th className="listTitle">Company name</th>
              <th className="listTitle">edit</th>
            </tr>
          </thead>

          {
          companies && 
          companies.map(company => (
            <tbody
              key={company.id}
              className="listWrapper" 
              onClick={() => handleRedirect(company.id)}
            >
              <tr className="listBody">
                <td>{company.name}</td>
                <td>{company.location}</td>
              </tr>
            </tbody>
          ))
        }
        </table>
        {isAdmin ? (
          <div className="modal-add" onClick={() => setModalAdd(true)}>
            Add <span className="modal__add">+</span>
          </div>
        ) : null}
        {modalAdd ? (
          <ModalAdd
            state={companies}
            setState={setCompanies}
            data={modalData}
            show={modalAdd}
            setModal={setModalAdd}
          />
        ) : null}

        <Pagination
          itemsCount={companyList.count}
          pageSize={companyList.pageSize}
          onPageChange={handlePageChange}
          currentPage={companyList.currentPage}
      />
</section>

  </>
);
}

export default CompanyList;