LoLGears
========

Windows app that tracks your lifetime game history based on LoL's debug logs.  
Download here: https://github.com/hansonw/LoLGears/releases
  
![Summoner List](http://i.imgur.com/f2SBstW.png)
![Game History](http://i.imgur.com/9NFLYxL.png)
More screenshots at http://imgur.com/a/RTlrk  
Reddit post: http://www.reddit.com/r/leagueoflegends/comments/1oulw8

Features:
- Full game listing, including summoners, champions, death logs + win/loss records.
- Aggregated statistics of all summoners you've played with.
- Detailed summoner statistics, including record as/with/against.

Notes and Limitations:
- Uses log files in `C:\Riot Games\League of Legends\Logs\Game - R3d logs`.  
  If you've re-formatted / deleted the LoL directory at some point,
  statistics for games before then won't be available.
- It doesn't seem possible to distinguish between ranked/normal/customs.
- There is no way to track a summoner across name changes.
- Game win/losses are only available after patch 3.10.0.237 (2013-07-31).
    - Bot games are not included in wins and losses.
- The identity of the player is not certain before 3.01.0.1 (2013-02-01).
  However, I try to intelligently guess based on how often a name appears.
  This should be fine for most cases, unless you swapped account with
  a friend or something like that.
- Server regions aren't logged before 1.0.0.150 (2012-10-25).
  This shouldn't affect you unless you've used the same summoner name
  across two servers before that date.
- It's hard to detect bots with 100% certainty; it's possible that some
  custom bot games are undetected.
  (Summoner names like "Annie Bot" should work fine though!)
