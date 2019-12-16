import _ from "lodash";

export const paginate = (items, pageNumber, pageSize) =>  {
  const startIndex = (pageNumber - 1) * pageSize; 
  //Convert Lodash to a warpper with _() hereby we can chaning methods instead of returning.  
  return _(items).slice(startIndex).take(pageSize).value();
}