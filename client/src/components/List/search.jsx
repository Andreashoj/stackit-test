import React from 'react';

const Search = ({value, onChange}) => {
return (
  <form action="">
    <input  type="text" 
            className="searchInput"
            name="query" 
            value={value.searchQuery} 
            onChange={e => onChange(e.currentTarget.value)} 
    />
  </form>
);
}

export default Search;