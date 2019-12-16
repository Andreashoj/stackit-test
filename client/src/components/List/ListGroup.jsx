import React from 'react';

const ListGroup = ({items}) => {

return (
  <section className="List-wrapper">
        <table className="listWrapper">
          <thead className="listHead">
            <th className="listTitle">Unit</th>
            <th className="listTitle">K_ope name</th>
            <th className="listTitle">Edit</th>
          </thead>

          {opes.map(ope => (
            <tbody
              className="listWrapper"
              /* onClick={() => handleRedirect(ope._id)} */
            >
              <tr className="listBody" key={ope._id}>
                <td>{ope._id}</td>
                <td>{ope.name}</td>
                <td>
                  <a href="#" onClick={e => handleEdit(e, ope)}>
                    Edit
                  </a>
                  <a href="#" onClick={e => handleDelete(e, ope)}>
                    Delete
                  </a>
                </td>
              </tr>
            </tbody>
          ))}
        </table>

        <Pagination
          itemsCount={opeState.count}
          pageSize={opeState.pageSize}
          onPageChange={handlePageChange}
          currentPage={opeState.currentPage}
        />
      </section>
);
}

export default ListGroup;