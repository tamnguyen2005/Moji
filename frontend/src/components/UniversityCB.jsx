import { useSearchParams } from "react-router-dom";

const UniversityCB = ({ university }) => {
  const [searchParam, setSearchParam] = useSearchParams();
  const existing = searchParam.getAll("universityId");
  const universityIds = existing.flatMap((value) =>
    value.split("||").filter(Boolean),
  );
  const isChecked = universityIds.includes(String(university.id));

  const OnCBChange = () => {
    const param = new URLSearchParams(searchParam);
    const ids = param
      .getAll("universityId")
      .flatMap((value) => value.split("||").filter(Boolean));

    const nextIds = isChecked
      ? ids.filter((id) => id !== String(university.id))
      : [...new Set([...ids, String(university.id)])];

    param.delete("universityId");
    nextIds.forEach((id) => param.append("universityId", id));
    if (!nextIds.length) {
      param.delete("universityId");
    }
    setSearchParam(param);
  };

  return (
    <label className="flex items-center gap-3 cursor-pointer">
      <input
        type="checkbox"
        checked={isChecked}
        onChange={OnCBChange}
        className="w-4 h-4 rounded border-gray-300 text-blue-600"
      />
      <span className="text-sm text-gray-700">{university.name}</span>
    </label>
  );
};
export default UniversityCB;
