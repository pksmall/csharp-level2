# csharp-level2
## C# level2 course from GeekBrains

## lesson04 branch homework04
1. �������� � ��������� ��������� ����������. ��� ������ ��� ������������� (��� ��������� �����), ����������� ����� ���������, � ������� �� 1 �������� ������.
2. ���� ��������� `List<T>`, ��������� ����������, ������� ��� ������ ������� ����������� � ������ ���������:
 - �) ��� ����� �����;
 - �) *��� ���������� ���������;
 - �) *��������� Linq.
3. *��� �������� ���������:
```csharp
Dictionary<string, int> dict = new Dictionary<string, int>()
  {
    {"four",4 },
    {"two",2 },
    { "one",1 },
    {"three",3 },
  };
var d = dict.OrderBy(delegate(KeyValuePair<string,int> pair) { return pair.Value; });
foreach (var pair in d)
{
    Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
}        
```
- �) �������� ��������� � OrderBy � �������������� ������-��������� $.
- �) *���������� ��������� � OrderBy � �������������� �������� Predicate<T>.


## lesson03 branch homework03
1. �������� ����������� �������, ��� ������� � �����.
2. ����������� ���� �����������.
 - �) �������� ������� ������� � ������� � ������� ���������;
 - �) *�������� ��� � � ����.
3. ����������� �������, ������� ��������� �������.
4. �������� ������� ����� �� ������ ���������.
5. *�������� � ������ Lesson3 ���������� �������.

## lesson02 branch homework02
1. ��������� ��� ������ (������� � 2 �������), ����������� ���� ����������: � ��������� ������� (���� �� ��������) � ������������� ������� (������ �������).
 - �) ������� � ������� ������ ����������� ����� ��� ������� �������������� ���������� �����. ��� �������������� ������� ��� ������� ������: ��������������� ���������� ����� = 20.8 * 8 * ��������� ������. ��� ���������� � ������������� �������: ��������������� ���������� ����� = ������������� �������� ������.
 - �) ������� �� ���� ������������ ������ ������ ����������� � ��������� ���.
 - �) *����������� ���������� ��� ����������� ���������� �������, ��������� Array.Sort().
 - �) *������� �����, ���������� ������ �����������, � ����������� ����������� ������ ������ � �������������� foreach.
2. ���������� ����������� ����� Update � BaseObject � ����������� � ����������� ��� � �����������.
3. ������� ���, ����� ��� ������������� ���� � ���������� ��� ���������������� � ������ ������ ������.
4. ������� �������� �� ������� ������� ������ � ������ Game. ���� ������ ��� ������ (Width, Height) ������ 1000 ��� ��������� ������������� ��������, ��������� ���������� ArgumentOutOfRangeException().
5. *������� ����������� ���������� GameObjectException, ������� ���������� ��� ������� ������� ������ � ������������� ���������������� (��������, ������������� �������, ������� ������� �������� ��� �������).

## lesson01 branch homework01
1. �������� ���� ������� � �������� ��������, ����� ��������� �������� ������ ���, ������� �� ����� � �������� ������������.
2. *�������� �������� ����������, ��������� ����� DrawImage.
3. *����������� ����������� ����� �������� SplashScreen, ����������� ������ Game. �������� � ��� ����������� �������� �������� � ������� �� ��������. ������������� ������ ������� �����, ���������, ������. �������� �� �������� ��� ������.

