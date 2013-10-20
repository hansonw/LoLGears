LoLGears
========

App that shows your lifetime game history based on LoL's debug logs.
These can usually be found in:
  C:\Riot Games\League of Legends\Logs\Game - R3d logs.

Features:
- Full game listing, including summoners, champions, death logs + win/loss.
- Aggregated statistics of all summoners you've played with.
- Detailed summoner statistics, including record as/with/against.

Limitations:
- If you've re-formatted / deleted the LoL directory at some point,
  statistics for games before then won't be available.
- Game win/losses are only available after patch 3.10.0.237 (2013-07-31).
- The identity of the player is not certain before 3.01.0.1 (2013-02-01).
  However, I try to intelligently guess based on how often a name appears.
  This should be fine for most cases, unless you swapped account with
  a friend or something like that.
- Server regions aren't logged before 1.0.0.150 (2012-10-25).
  This shouldn't affect you unless you've used the same summoner name
  across two servers before that date.
- It's hard to detect bots with 100% certainty; it's possible for bots to
  show up in the statistics.
