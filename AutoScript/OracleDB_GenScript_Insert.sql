--SET SERVEROUTPUT ON
DECLARE
  v_table_name VARCHAR2(30) := 'TOK_TABLE'; -- ⚠️ đổi tên bảng ở đây
  v_insert CLOB := 'INSERT INTO '||v_table_name||' (';
  v_select CLOB := 'SELECT ';
BEGIN
  FOR rec IN (
    SELECT column_name, data_type, data_precision, data_scale, char_length, column_id
    FROM all_tab_columns
    WHERE table_name = UPPER(v_table_name)
    ORDER BY column_id
  ) LOOP
    -- danh sách cột
    v_insert := v_insert || rec.column_name || ',';

    -- giá trị random theo kiểu dữ liệu
    IF rec.data_type LIKE 'VARCHAR2%' THEN
      v_select := v_select || 'SUBSTR(DBMS_RANDOM.STRING(''X'','||rec.char_length||'+10),1,'||rec.char_length||') AS '||rec.column_name||',';
    ELSIF rec.data_type = 'NUMBER' THEN
      IF rec.data_scale IS NULL OR rec.data_scale = 0 THEN
        v_select := v_select || 'TRUNC(DBMS_RANDOM.VALUE(0,POWER(10,'||rec.data_precision||'))) AS '||rec.column_name||',';
      ELSE
        v_select := v_select || 'ROUND(DBMS_RANDOM.VALUE(0,POWER(10,'||(rec.data_precision-rec.data_scale)||')),'
                   ||rec.data_scale||') AS '||rec.column_name||',';
      END IF;
    ELSIF rec.data_type = 'DATE' THEN
      v_select := v_select || 'TRUNC(SYSDATE - DBMS_RANDOM.VALUE(0,365)) AS '||rec.column_name||',';
    ELSE
      v_select := v_select || 'NULL AS '||rec.column_name||',';
    END IF;
  END LOOP;

  -- hoàn thiện câu lệnh
  v_insert := RTRIM(v_insert, ',') || ') ';
  v_select := RTRIM(v_select, ',') || ' FROM dual CONNECT BY LEVEL <= 10;';

  DBMS_OUTPUT.PUT_LINE(v_insert || v_select);
END;