#		How to read this
If you wandered in here out of curiosity, this is my working notes file, and completed/planned feature list. It's in Markdown, but best viewed in raw form since a lot of its organization has to do with text characters' alignment.

Listed in order of Parent tier summary symbol priority:
	C, T = Code this, Test this
	H = Hold, usually pending resolution of a separate or grouped issue
	√ = Fully implemented feature or group of features
#		General
Fatass has a few new features listed in description
##		C	Manual Loader
16 PIV
All wasted ammo (from pickups or Ammunizer) is converted into XP at the rate of 1 per bullet
#		Traits
##		C	Close Combat
###			C	00 BM Importation
MeleeHitbox.
	HitObject			C
	MeleeHitEffect		C
###			C	Hit Supernatural
###			C	Hit Mundane
###			C	Damage
###			C	Blessed Strikes / +
###			C	Cursed Strikes / +
###			C	Infernal Strikes / +
###			C	Venomous Strikes / +
##		C	Experience Events
Possible rewrite:
Path of Ash - Fire
Path of Chaos - Anti-Law
Path of Death - Bad stuff & killing
Path of Gold - Earning & Spending, buying & selling
Path of Life - Good stuff & healing
Path of Order - Law
Path of Shadows - Stealth
Path of Water (rename) - Water
###			C	Guilty Conscience
Enable Cop mali
###			C	Flagellant
Enable new mali including Cop ones (full extension of guilty conscience)
Double all mali
###			H	Very Hard-On Yourself
####			C	Split
Guilty Conscience: Cop Mali
Flagellant: Doubled mali, extra mali
####			T	Custom Mali
####			C	All BQ Penalties triggered
##		C	Item Restrictions
###			C!	00 CC Items not spawning in inventory
Banana didn't appear in inv with Carnivore, loud stuff with Afraid.
###			T	Test with NPCs
P_InvDatabase.ChooseWeapon_FilterItemList
Didn't seem to work on player character. Might be for NPCs only.
InvDatabase.UpdateWeaponList2 seems to be the NPC version of InvDatabase.ChooseWeapon()
###			C	Restrict Usables
Time Bomb, etc.
###			T	Afraid of Loud Noises
###			T	Carnivore
###			T	DAREdevil
###			T	Draw No Blood
###			T	Fat Head
###			T	Fatass
New features, add here
###			T	Friend of Bill
###			T	Teetotaller
###			T	Vegetarian
##		√	Quest Count
###			√	Rushin' Revolution
###			√	Single-Minded
###			√	Workhorse
##		C	Quest Rewards
Do not make them compatible, the logic will be a mess.
Can make a Prize Bag one later on if you feel like it, to randomly select one.
###			C!	00 Banana Count 0 Item Rewards
Banana peel, count 0
###			H	Double-Ply Rewards
Item only
###			H	Lump Sum
####			H	Double money
Pending 00 Item Rewards above
####			C	No XP
###			H	Monkey Rewards
Reward banaan
HR made a typo
###			H	Unpaid Internship
####			C	Double XP
####			H	No Money
Pending 00 Item Rewards above
####			C	One ham sandwich per level
##		C	Ranged Combat
###			C	00 BM Importation
This doesn't need to mean the new code works, only that you've got what you need out of the old stuff.
Bullet.
	SetupBullet			√
	LateUpdateBullet	√
BulletHitbox.
	HasLOSBullet		√
	HitObject			C	(Sniper + Shot past cover)
PlayfieldObject.
	FindDamage			C	
###			C	Sniper
####			C	Damage
####			C	Range
###			C	Sniper +
####			C	Bypass Cover Object
BulletHitbox.HitObject
This was NOT working yet in BM
I've deleted that old method since salvaging it would be more work than it's worth.
No currently activated attempt yet.
#####				C	00 BM Notes
- Attempted with BulletHitbox.OnTriggerEnter2D
  - DW, but see what logs are saying before deletion
- Check out vTrait.BulletsPassThroughObjects. It's in BulletHitBox.HitObject
- Consider Bullet.RayHit
- Model this one on Penetrating Bullets: BulletHitbox.HitObject
  - Attempted 
    - (If this doesn't work, try with eliminating BulletHitBox.OnTriggerEnter2d patch next)
- PFO.bulletsCanPass may determine raycast end of bullet
- Give some visual indicator, either as a SPecial Indicator over NPCs, or a color change on the aiming reticle, when you are able to do a headshot
- Ability Indicator at Range
  - May need to trigger StatusEffects.SpecialAbilityInterfaceCheck as if adding a Special Ability. Not sure this will be doable with a trait.
    - Call it in AddTrait.
  - Attempted
    - StatusEffect.AddTrait
    - StatusEffects.SpecialAbilityInterfaceCheck
    - Used placeholder Chloroform sprite
    - Used placeholder range without 2f range mod from hiding
####			C	Sprite Target Indicator
Agent.SpecialAbilityInterfaceCheck2
###			C	Wetworker
####			C	Damage
####			C	Range
####			C	Helmet Damage Reduction
This should be the "oh shit" snag for a Wetworker. 
##		C	Vision Range
###			C	Agent Activation
###			C	Object Activation
###			C	Imported BM Notes
- View range Agent & Object activation
  - ObjectRealOnCamera
    - Attempted
  - BrainUpdate.RogueVisionChecks()
  - BrainUpdate.DoObjectChecks()
  - Agent.AgentOnCamera()
    - This worked, but now they don't animate. They walk around statically, often tilted or upside down.
      - Attempted, Agent.Start
  - Agent.onCamera
  - Agent.wasOnCamera
  - PlayerAgent.agentCamera.ZoomFactor
  - PlayerControl.myCamera.zoomLevel
  - CameraScript.RealAwake
###			√	Eagle Eyes / +
###			T	Myopic / +
##		√	Experience Rate
###			√	Brainiac
###			√	Dim Bulb
###			√	Moron the Merrier
###			√	Smooth-Brained