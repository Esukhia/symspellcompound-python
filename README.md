# SymSpellCompound-tests
tests for SymSpellCompound

## TODO

* line 148: with open(path, 'r', encoding='utf-8') as f:
* fix bugs

In comparison with the weird behaviours described in test.py, here's a couple of tests done with SymSpell in C#:

Dictionary:

    bonjour 123
    bonjar 12344
    bonjaur 1234

Corrections:

    Trinleys-MBP:SymSpell.CompoundDemo trinley$ dotnet run
    Dictionary: 13 words, 346 entries, edit distance=2 in 66.0ms 0 MB
    bonjur
    bonjar 1 12,344
    bonjuur
    bonjaur 1 1,234
