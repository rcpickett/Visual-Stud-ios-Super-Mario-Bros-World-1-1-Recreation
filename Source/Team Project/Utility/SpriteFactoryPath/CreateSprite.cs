using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public static class CreateSprite
    {
        public const string CreateSmallCastle = "CreateSmallCastle";
        public const string CreateFlag = "CreateFlag";
        public const string CreatePole = "CreatePole";
        public const string CreateCastleFlag = "CreateCastleFlag";

        // Mario
        public const string SmallMarioIdleRight = "SmallMarioIdleRight";
        public const string SmallMarioIdleLeft = "SmallMarioIdleLeft";
        public const string BigMarioIdleRight = "BigMarioIdleRight";
        public const string BigMarioIdleLeft = "BigMarioIdleLeft";
        public const string FireMarioIdleRight = "FireMarioIdleRight";
        public const string FireMarioIdleLeft = "FireMarioIdleLeft";
        public const string SmallMarioRunningRight = "SmallMarioRunningRight";
        public const string SmallMarioRunningLeft = "SmallMarioRunningLeft";
        public const string BigMarioRunningRight = "BigMarioRunningRight";
        public const string BigMarioRunningLeft = "BigMarioRunningLeft";
        public const string FireMarioRunningRight = "FireMarioRunningRight";
        public const string FireMarioRunningLeft = "FireMarioRunningLeft";
        public const string SmallMarioJumpingRight = "SmallMarioJumpingRight";
        public const string SmallMarioJumpingLeft = "SmallMarioJumpingLeft";
        public const string BigMarioJumpingRight = "BigMarioJumpingRight";
        public const string BigMarioJumpingLeft = "BigMarioJumpingLeft";
        public const string FireMarioJumpingRight = "FireMarioJumpingRight";
        public const string FireMarioJumpingLeft = "FireMarioJumpingLeft";
        public const string BigMarioCrouchingRight = "BigMarioCrouchingRight";
        public const string BigMarioCrouchingLeft = "BigMarioCrouchingLeft";
        public const string FireMarioCrouchingRight = "FireMarioCrouchingRight";
        public const string FireMarioCrouchingLeft = "FireMarioCrouchingLeft";
        public const string MarioDeadRight = "MarioDeadRight";
        public const string MarioDeadLeft = "MarioDeadLeft";
        public const string SmallMarioTurningLeft = "SmallMarioTurningLeft";
        public const string SmallMarioTurningRight = "SmallMarioTurningRight";
        public const string BigMarioTurningLeft = "BigMarioTurningLeft";
        public const string BigMarioTurningRight = "BigMarioTurningRight";
        public const string FireMarioTurningLeft = "FireMarioTurningLeft";
        public const string FireMarioTurningRight = "FireMarioTurningRight";
        public const string BigSmallMarioRight = "BigSmallMarioRight";
        public const string BigSmallMarioLeft = "BigSmallMarioLeft";
        public const string BigMarioSwimIdleRight = "BigMarioSwimIdleRight";
        public const string BigMarioSwimIdleLeft = "BigMarioSwimIdleLeft";
        public const string SmallMarioSwimIdleRight = "SmallMarioSwimIdleRight";
        public const string SmallMarioSwimIdleLeft = "SmallMarioSwimIdleLeft";
        public const string FireMarioFireballRight = "FireMarioFireballRight";
        public const string FireMarioFireballLeft = "FireMarioFireballLeft";
        public const string SmallMarioWinningLegDownRight = "SmallMarioWinningLegDownRight";
        public const string SmallMarioWinningLegUpRight = "SmallMarioWinningLegUpRight";
        public const string SmallMarioWinningLegDownLeft = "SmallMarioWinningLegDownLeft";
        public const string SmallMarioWinningLegUpLeft = "SmallMarioWinningLegUpLeft";
        public const string BigMarioWinningArmDownRight = "BigMarioWinningArmDownRight";
        public const string BigMarioWinningArmUpRight = "BigMarioWinningArmUpRight";
        public const string BigMarioWinningArmDownLeft = "BigMarioWinningArmDownLeft";
        public const string BigMarioWinningArmUpLeft = "BigMarioWinningArmUpLeft";
        public const string FireMarioWinningArmDownRight = "FireMarioWinningArmDownRight";
        public const string FireMarioWinningArmUpRight = "FireMarioWinningArmUpRight";
        public const string FireMarioWinningArmDownLeft = "FireMarioWinningArmDownLeft";
        public const string FireMarioWinningArmUpLeft = "FireMarioWinningArmUpLeft";

        // Luigi
        public const string SmallLuigiIdleRight = "SmallLuigiIdleRight";
        public const string SmallLuigiIdleLeft = "SmallLuigiIdleLeft";
        public const string BigLuigiIdleRight = "BigLuigiIdleRight";
        public const string BigLuigiIdleLeft = "BigLuigiIdleLeft";
        public const string FireLuigiIdleRight = "FireLuigiIdleRight";
        public const string FireLuigiIdleLeft = "FireLuigiIdleLeft";
        public const string SmallLuigiRunningRight = "SmallLuigiRunningRight";
        public const string SmallLuigiRunningLeft = "SmallLuigiRunningLeft";
        public const string BigLuigiRunningRight = "BigLuigiRunningRight";
        public const string BigLuigiRunningLeft = "BigLuigiRunningLeft";
        public const string FireLuigiRunningRight = "FireLuigiRunningRight";
        public const string FireLuigiRunningLeft = "FireLuigiRunningLeft";
        public const string SmallLuigiJumpingRight = "SmallLuigiJumpingRight";
        public const string SmallLuigiJumpingLeft = "SmallLuigiJumpingLeft";
        public const string BigLuigiJumpingRight = "BigLuigiJumpingRight";
        public const string BigLuigiJumpingLeft = "BigLuigiJumpingLeft";
        public const string FireLuigiJumpingRight = "FireLuigiJumpingRight";
        public const string FireLuigiJumpingLeft = "FireLuigiJumpingLeft";
        public const string BigLuigiCrouchingRight = "BigLuigiCrouchingRight";
        public const string BigLuigiCrouchingLeft = "BigLuigiCrouchingLeft";
        public const string FireLuigiCrouchingRight = "FireLuigiCrouchingRight";
        public const string FireLuigiCrouchingLeft = "FireLuigiCrouchingLeft";
        public const string LuigiDeadRight = "LuigiDeadRight";
        public const string LuigiDeadLeft = "LuigiDeadLeft";
        public const string SmallLuigiTurningLeft = "SmallLuigiTurningLeft";
        public const string SmallLuigiTurningRight = "SmallLuigiTurningRight";
        public const string BigLuigiTurningLeft = "BigLuigiTurningLeft";
        public const string BigLuigiTurningRight = "BigLuigiTurningRight";
        public const string FireLuigiTurningLeft = "FireLuigiTurningLeft";
        public const string FireLuigiTurningRight = "FireLuigiTurningRight";
        public const string BigSmallLuigiRight = "BigSmallLuigiRight";
        public const string BigSmallLuigiLeft = "BigSmallLuigiLeft";
        public const string BigLuigiSwimIdleRight = "BigLuigiSwimIdleRight";
        public const string BigLuigiSwimIdleLeft = "BigLuigiSwimIdleLeft";
        public const string SmallLuigiSwimIdleRight = "SmallLuigiSwimIdleRight";
        public const string SmallLuigiSwimIdleLeft = "SmallLuigiSwimIdleLeft";
        public const string FireLuigiFireballRight = "FireLuigiFireballRight";
        public const string FireLuigiFireballLeft = "FireLuigiFireballLeft";
        public const string SmallLuigiWinningLegDownRight = "SmallLuigiWinningLegDownRight";
        public const string SmallLuigiWinningLegUpRight = "SmallLuigiWinningLegUpRight";
        public const string SmallLuigiWinningLegDownLeft = "SmallLuigiWinningLegDownLeft";
        public const string SmallLuigiWinningLegUpLeft = "SmallLuigiWinningLegUpLeft";
        public const string BigLuigiWinningArmDownRight = "BigLuigiWinningArmDownRight";
        public const string BigLuigiWinningArmUpRight = "BigLuigiWinningArmUpRight";
        public const string BigLuigiWinningArmDownLeft = "BigLuigiWinningArmDownLeft";
        public const string BigLuigiWinningArmUpLeft = "BigLuigiWinningArmUpLeft";
        public const string FireLuigiWinningArmDownRight = "FireLuigiWinningArmDownRight";
        public const string FireLuigiWinningArmUpRight = "FireLuigiWinningArmUpRight";
        public const string FireLuigiWinningArmDownLeft = "FireLuigiWinningArmDownLeft";
        public const string FireLuigiWinningArmUpLeft = "FireLuigiWinningArmUpLeft";

        //Bowser
        public const string BowserIdleRight = "bowseridleright";
        public const string BowserRunningRight = "bowserrunningright";
        public const string BowserIdleLeft = "bowseridleleft";
        public const string BowserRunningLeft = "bowserrunningleft";
        public const string BigBowserRunningLeft = "bigbowserrunleft";
        public const string BigBowserRunningRight = "bigbowserrunright";
        public const string BigBowserIdleLeft = "bigbowserfaceleft";
        public const string BigBowserIdleRight = "bigbowserfaceright";
        public const string GigaBowserRunningLeft = "GigaBowserrunleft2";
        public const string GigaBowserRunningRight = "GigaBowserrunright2";
        public const string GigaBowserIdleLeft = "GigaBowseridleleft";
        public const string GigaBowserIdleRight = "GigaBowseridleright";
    }
}
